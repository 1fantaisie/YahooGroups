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
    public partial class MembersList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isModerator = false;
            string query = "SELECT * FROM GroupMembers WHERE theGroup=@theGroup AND username=@username";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                String t = Request.QueryString["t"];
                com.Parameters.AddWithValue("theGroup", t);
                com.Parameters.AddWithValue("username", Context.User.Identity.GetUserName());
                SqlDataReader reader = com.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {

                    if (reader["moderator"].ToString() == "1")
                        isModerator = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                EroareBazaDate.Text = "Eroare din baza de date: " + ex.Message;
            }
            query = "SELECT * FROM GroupMembers WHERE theGroup=@theGroup";  
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                String t = Request.QueryString["t"];
                com.Parameters.AddWithValue("theGroup", t);
                SqlDataReader reader = com.ExecuteReader();
                
                int i = 0;
                while (reader.Read())
                {
                    Users.Text += "<tr><td> " + reader["username"].ToString() + " </td>";
                    if (reader["moderator"].ToString() == "1")
                        Users.Text += "<td> Moderator </td>";
                    else
                        Users.Text += "<td> User </td>";
                    if (isModerator && reader["moderator"].ToString() != "1")
                        Users.Text += "<td><a href='RemoveMember.aspx?u=" + reader["username"] + "&t="+t+"'>Remove member</a>";
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