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
    public partial class Topic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ReplyMessage.Visible = false;
                Reply.Visible = false;
            }
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
            con.Open();
          
           string  query = "SELECT * FROM replies WHERE title=@title";
            try
            {
                String t = Request.QueryString["t"];
                TopicTitle.Text = t;
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("title", t);
                SqlDataReader reader = com.ExecuteReader();

                // Citim rand cu rand din baza de date
                int i = 0;
                while (reader.Read())
                {
                    Messages.Text += "<tr><td>" + reader["username"].ToString() + "</td>";
                    Messages.Text += "<td> " + reader["date"].ToString() + "</td></tr>";
                    Messages.Text += "<tr><td>" + reader["message"].ToString() + "</td></tr>";
                    //  Name.Text += "<td>" + reader["category"].ToString() + " </td></tr>";

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
        protected void reply(object sender, EventArgs e)
        {
            string query = "INSERT INTO  replies(title, message, date,username)  "
                       + " VALUES ( @title, @message, @date,@username)";
            string _Message = ReplyMessage.Text;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
            con.Open();
            try
            {
                // Introducem parametrii in cererea SQL
                SqlCommand com = new SqlCommand(query, con);
                // primul parametru, nume, este din query reprezentat de @nume iar _Nume este valoarea variabilei din formular
                String t = Request.QueryString["t"];
                String parent = Request.QueryString["parent"];
                com.Parameters.AddWithValue("title", t);
                com.Parameters.AddWithValue("message", _Message);
                com.Parameters.AddWithValue("date", DateTime.Now);
                com.Parameters.AddWithValue("username", Context.User.Identity.GetUserName());


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
                Response.Redirect(String.Format("~/Topic.aspx?t={0}", this.TopicTitle.Text));
            }
            catch (Exception ex)
            {
                EroareBazaDate.Text = "Eroare din baza de date: " + ex.Message;
            }
            finally
            {
                // Nu o lasam deschisa.
                con.Close();
            }
        
    }
    }
}