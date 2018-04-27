using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YahooGroups
{
    public partial class RemoveMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String t = Request.QueryString["t"];
            String u = Request.QueryString["u"];
         
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
            con.Open();
           string query = "DELETE"
                  + " FROM GroupMembers"
                  + " WHERE username = @username AND thegroup=@thegroup";


            try
            {
               
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("username", u);
                com.Parameters.AddWithValue("thegroup", t);
                int deleted = com.ExecuteNonQuery();

                if (deleted > 0)
                {
                    Response.Write("Intrarea a fost stearsa din baza de date");
                }
                else
                {
                    Response.Write("Intrarea nu a fost stearsa. Va rugam incercati din nou");
                }

            }
            catch (Exception ex)
            {
                Response.Write("Eroare din baza de date: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            Response.Redirect(String.Format("~/MembersList.aspx?t={0}", t));
        }
    }
}