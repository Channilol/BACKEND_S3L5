using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerceEpicode.MasteryPages
{
    public partial class TemplateBase : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCartNumber();
        }

        public void LoadCartNumber()
        {
            string connString = ConfigurationManager.ConnectionStrings["connectionToDatabase"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand getCart = new SqlCommand("SELECT count(*) as totNumCart FROM Carrello", conn);
                SqlDataReader numbCart = getCart.ExecuteReader();
                if (numbCart.HasRows)
                {
                    while (numbCart.Read())
                    {
                        numCart.Text = numbCart["totNumCart"].ToString();
                    }
                }
                else
                {
                    Response.Write("Operazione fallita");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}