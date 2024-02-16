using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerceEpicode
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["connectionToDatabase"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand getProducts = new SqlCommand("SELECT * FROM Prodotti", conn);
                SqlDataReader reader = getProducts.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        productContainer.InnerHtml += $"<div class='productCard'><a href='/Product.aspx?id={reader["Id"]}'><div class='productCardImg'><img src='{reader["Image"]}' alt='productImage'/></div><div class='productCardTxt'><h2>{reader["Nome"]}</h2><h3>{reader["Brand"]}</h3><p>{reader["Prezzo"]}€</p></div></a></div>";
                    }
                }
                else
                {
                    Response.Write("Operazione fallita");
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