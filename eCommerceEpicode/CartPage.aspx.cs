using eCommerceEpicode.MasteryPages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace eCommerceEpicode
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showTotPrice();
            ShowCart();
        }

        protected int totCart = 0;

        protected void ShowCart()
        {
            string connString = ConfigurationManager.ConnectionStrings["connectionToDatabase"].ToString();
            List<dynamic> products = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = @"SELECT car.Id as IdCarrello, IdProdotto, Quantità, Nome, Brand, Prezzo, Image FROM Carrello car LEFT JOIN Prodotti pro ON car.IdProdotto = pro.Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new
                            {
                                IdCarrello = reader["IdCarrello"],
                                IdProdotto = reader["IdProdotto"],
                                Img = reader["Image"],
                                Nome = reader["Nome"],
                                Brand = reader["Brand"],
                                Quantità = reader["Quantità"],
                                Prezzo = reader["Prezzo"],
                            }) ;
                        }
                    }

                }

                cartRepeater.DataSource = products;
                cartRepeater.DataBind();
            }
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["connectionToDatabase"].ToString();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "DELETE FROM Carrello WHERE Id = @IdCarrello";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdCarrello", Convert.ToInt32(e.CommandArgument));
                    cmd.ExecuteNonQuery();
                }
            }
            var masterPage = this.Master as TemplateBase;
            if (masterPage != null)
            {
                masterPage.LoadCartNumber();
            }
            showTotPrice();
            ShowCart();
            lblDeletedProd.Text = "Prodotto rimosso dal carrello";
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["connectionToDatabase"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand deleteItem = new SqlCommand($"DELETE FROM Carrello", conn);
                int affectedRow = deleteItem.ExecuteNonQuery();
                if (affectedRow == 0)
                {
                    Response.Write("C'è stato un errore nella eliminazione dei prodotti");
                }
                var masterPage = this.Master as TemplateBase;
                if (masterPage != null)
                {
                    masterPage.LoadCartNumber();
                }
                showTotPrice();
                ShowCart();
                lblDeletedProd.Text = "Carrello svuotato!";
            }
            catch (Exception ex)
            {
                Response.Write($"{ex}");
            }
            finally
            {
                conn.Close();
            }
        }

        protected void showTotPrice()
        {
            string connString = ConfigurationManager.ConnectionStrings["connectionToDatabase"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            try 
            {
                conn.Open();
                SqlCommand getTotPrice = new SqlCommand("SELECT sum(pro.Prezzo * car.Quantità) as sumPrice FROM Carrello car LEFT JOIN Prodotti pro ON car.IdProdotto = pro.Id", conn);
                SqlDataReader reader = getTotPrice.ExecuteReader();
                if(reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string stringSumPrice = reader["sumPrice"].ToString(); 
                        if (stringSumPrice == "0")
                        {
                            lblSumPrice.Text = "Totale carrello: 0€";
                        }
                        else
                        {
                            lblSumPrice.Text = $"Totale carrello: {stringSumPrice}€";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"{ex}");
            }
            finally
            {
                conn.Close();
            }

        }
        
    }
}