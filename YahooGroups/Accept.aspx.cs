using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YahooGroups
{
    public partial class Accept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String t = Request.QueryString["t"];
            String u = Request.QueryString["u"];
            string query = "INSERT INTO  GroupMembers  "
                       + " VALUES ( @username, @group, @moderator)";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
            con.Open();
            try
            {
                // Introducem parametrii in cererea SQL
                SqlCommand com = new SqlCommand(query, con);
                // primul parametru, nume, este din query reprezentat de @nume iar _Nume este valoarea variabilei din formular

                com.Parameters.AddWithValue("username",u );
                com.Parameters.AddWithValue("group", t);
                com.Parameters.AddWithValue("moderator", 0);
              

                int id = (int)com.ExecuteNonQuery();
               
                // Update, delete si insert sunt NON QUERY -> nu returneaza un SqlReader
                if (id > 0)
                {
                    EroareBazaDate.Text = "Informatiile au fost adaugate";
                }
                else
                {
                    EroareBazaDate.Text = "Informatiile nu au fost adaugate";
                }

            }
            catch (Exception ex)
            {
                EroareBazaDate.Text = "Eroare din baza de date: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
             query = "DELETE"
                   + " FROM pendingRequests"
                   + " WHERE username = @username AND thegroup=@thegroup";

            
            try
            {
                con.Open();               
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
            Response.Redirect(String.Format("~/Group.aspx?t={0}", t));
        }
    }
}