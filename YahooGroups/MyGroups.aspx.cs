using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
namespace YahooGroups
{
    public partial class MyGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM GroupMembers WHERE username=@username";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                String t = Request.QueryString["t"];
                com.Parameters.AddWithValue("username", Context.User.Identity.GetUserName());
                SqlDataReader reader = com.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    Groups.Text += "<tr><td><a href='Group.aspx?t=" + reader["theGroup"].ToString() + "'>"+reader["theGroup"].ToString()+"</a> </td>";
                    if (reader["moderator"].ToString() == "1")
                        Groups.Text += "<td> Moderator </td>";
                    else
                        Groups.Text += "<td> User </td>";
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