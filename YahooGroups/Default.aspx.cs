using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YahooGroups
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                creategroup.Visible = false;
            }
                     string query = "SELECT * FROM groups";
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
                    con.Open();
                try
                {
                    SqlCommand com = new SqlCommand(query, con);
                    SqlDataReader reader = com.ExecuteReader();

                 int i = 0;
                while (reader.Read())
                {
                    Name.Text += "<tr><td> <a href='Group.aspx?t=" + reader["name"].ToString() + "'> " + reader["name"].ToString() + "</a> </td>";
                        Name.Text += "<td>"+reader["category"].ToString()+" </td>";
                    Name.Text += "<td>" + reader["description"].ToString() + "</td></tr>";

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
            }

        protected void Search(object sender, EventArgs e)
        {
            string query = "SELECT * FROM groups WHERE name=@name";
            string _Name = GroupName.Text;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
            con.Open();
            try
            {
                // Introducem parametrii in cererea SQL
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("name", _Name);
                // primul parametru, nume, este din query reprezentat de @nume iar _Nume este valoarea variabilei din formular
                SqlDataReader reader = com.ExecuteReader();

                // Citim rand cu rand din baza de date
                int i = 0;
                while (reader.Read())
                {
                    SearchedName.Text =  reader["name"].ToString() ;
                    SearchedName.NavigateUrl = "Group.aspx?t="+reader["name"].ToString();
                    SearchedCategory.Text =reader["category"].ToString();
                    SearchedDescription.Text =  reader["description"].ToString();

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
        }
    }
 }
