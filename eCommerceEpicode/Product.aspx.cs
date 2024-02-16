using eCommerceEpicode.MasteryPages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerceEpicode
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAddedToCart.Visible = false;
            string idProduct = HttpContext.Current.Request.QueryString["id"];

            string connString = ConfigurationManager.ConnectionStrings["connectionToDatabase"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                if(!string.IsNullOrEmpty(idProduct))
                {
                    SqlCommand getProduct = new SqlCommand($"SELECT * FROM Prodotti WHERE Id={idProduct}", conn);
                    SqlDataReader reader = getProduct.ExecuteReader();

                    if (reader.Read())
                    {
                        productImg.Attributes["src"] = reader["Image"].ToString();
                        productTxt.InnerHtml = $"<h2>{reader["Nome"]}</h2>" +
                            $"<h3>Marca: {reader["Brand"]}</h3>" +
                            $"<h4>Voto: {reader["Rate"]}/5,0</h4>" +
                            $"<p>{reader["Descrizione"]}</p>";
                        productTitle.Controls.Add(new Literal { Text = $"<a href='/Home.aspx'>Home</a> > {reader["Nome"]}" });

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

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            string idProduct = HttpContext.Current.Request.QueryString["id"];
            int selQuantita = Convert.ToInt32(quantita.SelectedValue);
            string connString = ConfigurationManager.ConnectionStrings["connectionToDatabase"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                if (selQuantita > 0)
                {
                    SqlCommand insertToCart = new SqlCommand($"INSERT INTO Carrello (IdProdotto, Quantità) VALUES ({idProduct}, {selQuantita})", conn);
                    int affectedRow = insertToCart.ExecuteNonQuery();
                    if (affectedRow == 0)
                    {
                        Response.Write("C'è stato un errore nella registrazione");
                    }
                    quantita.SelectedValue = "0";
                    var masterPage = this.Master as TemplateBase;
                    if (masterPage != null)
                    {
                        masterPage.LoadCartNumber();
                    }
                    lblAddedToCart.Visible = true;
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

        protected void quantita_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblQuantita.Text = $"Quantità: {quantita.SelectedValue}";
        }
    }
}