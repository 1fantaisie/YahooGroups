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
    public partial class Group : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                Pending.Visible = false;
           if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Name.Visible = false;
            }
            Name.NavigateUrl= "NewTopic.aspx?t="+Request.QueryString["t"];
            String t = Request.QueryString["t"];
            string query = "SELECT * FROM topics WHERE parentGroup=@parent";
            string query2 = "SELECT * FROM GroupMembers WHERE username=@username AND theGroup=@group";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
            con.Open();
            try
            {
                // Introducem parametrii in cererea SQL
                SqlCommand com = new SqlCommand(query, con);
              
                com.Parameters.AddWithValue("parent", t);
                SqlDataReader reader = com.ExecuteReader();

                // Citim rand cu rand din baza de date
                int i = 0;
                while (reader.Read())
                {
                    Topics.Text += "<tr><td> <a href='Topic.aspx?t=" + reader["title"].ToString() + "&parent="+t+"'> " + reader["title"].ToString() + "</a> </td>";
                    //  Name.Text += "<td>" + reader["description"].ToString() + "</td>";
                    //  Name.Text += "<td>" + reader["category"].ToString() + " </td></tr>";

                }
                reader.Close();
                com = new SqlCommand(query2, con);
                com.Parameters.AddWithValue("username", Context.User.Identity.GetUserName());
                com.Parameters.AddWithValue("group", t);
                reader = com.ExecuteReader();
                bool isMember=false;
                bool isModerator = false;
                if (reader.Read())
                {   isMember = true;
                    if (reader["moderator"].ToString() == "1")
                        isModerator = true;
                }
                reader.Close();
                if (isMember || !HttpContext.Current.User.Identity.IsAuthenticated) //neautentificat sau membru
                {
                    JoinGroupButton.Visible = false;
                    if (HttpContext.Current.User.Identity.IsAuthenticated && isModerator)//moderator
                    {
                       
                        string query3 = "SELECT * FROM PendingRequests WHERE theGroup=@group";
                        try
                        {
                            com = new SqlCommand(query3, con);
                            com.Parameters.AddWithValue("group", t);
                            reader = com.ExecuteReader();

                            while (reader.Read())
                            {
                                Requests.Text += "<tr><td>" + reader["username"].ToString() + "</td><td> <a href='Accept.aspx?t=" + reader["theGroup"].ToString() + "&u=" + reader["username"].ToString() + "'> Accept Request</a> </td>";

                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            EroareBazaDate.Text = "Eroare din baza de date: " + ex.Message;
                        }
                    }
                }
                if (isMember)
                { GroupMember.Visible = true;

                    MembersList.Visible = true;
                    MembersList.NavigateUrl = "MembersList.aspx?t="+t;
                }
                if(!isMember) //autentificat dar nu membru
                {
                    Name.Visible = false;
                    query = "SELECT * FROM PendingRequests WHERE username=@username AND theGroup=@group";
                    try
                    {
                        com = new SqlCommand(query, con);
                        com.Parameters.AddWithValue("username", Context.User.Identity.GetUserName());
                        com.Parameters.AddWithValue("group", t);
                        reader = com.ExecuteReader();
                        i = 0;
                        if (reader.Read())
                        {
                            JoinGroupButton.Visible = false;
                            Pending.Visible = true;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        EroareBazaDate.Text = "Eroare din baza de date: " + ex.Message;
                    }
                }

                }

            catch (Exception ex)
            {
                EroareBazaDate.Text = "Eroare din baza de date: " + ex.Message;
            }
           query = "SELECT * FROM groups WHERE name=@name";
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("name", t);
                SqlDataReader reader = com.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    GroupName.Text =  reader["name"].ToString();
                    GroupCategory.Text =reader["category"].ToString() ;
                    GroupDescription.Text =reader["description"].ToString();

                }
                reader.Close();

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

        protected void JoinGroup(object sender, EventArgs e)
        {
           
                string query = "INSERT INTO PendingRequests  "
                   + " VALUES ( @username, @group)";

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
                con.Open();
                try
                {
                    // Introducem parametrii in cererea SQL
                    SqlCommand com = new SqlCommand(query, con);
                    // primul parametru, nume, este din query reprezentat de @nume iar _Nume este valoarea variabilei din formular
                    String t = Request.QueryString["t"];
                    com.Parameters.AddWithValue("username", Context.User.Identity.GetUserName());
                    com.Parameters.AddWithValue("group", t);


                    int id = (int)com.ExecuteNonQuery();

                  
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
                    // Nu o lasam deschisa.
                    con.Close();
                Response.Redirect(string.Format("~/Default.aspx"));
            }
            }
    }
}
