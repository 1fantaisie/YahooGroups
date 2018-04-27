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
    public partial class NewTopic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddTopic(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                bool valid = true;

                string _Title = PostTitle.Text;
                string _Message = Message.Text;
              

                // TODO: Verificarea tuturor stringurilor de mai sus sau adaugarea validarilor in frontend
                if (_Title == "")
                {
                    valid = false;
                    Response.Write("Eroare: Numele nu poate fi gol");
                }

                if (valid)
                {
                    String t = Request.QueryString["t"];
                    string query = "INSERT INTO  topics(title, date, parentGroup)  "
                       + " VALUES ( @title,  @date, @parentGroup)";
                    string query2 = "INSERT INTO  replies  "
                       + " VALUES (  @message,@date,@title, @username)";
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
                    con.Open();
                    try
                    {
                        // Introducem parametrii in cererea SQL
                        SqlCommand com = new SqlCommand(query, con);
                        // primul parametru, nume, este din query reprezentat de @nume iar _Nume este valoarea variabilei din formular
                       
                        com.Parameters.AddWithValue("title", _Title);
                       
                        com.Parameters.AddWithValue("date", DateTime.Now);
                        com.Parameters.AddWithValue("parentGroup", t);


                        int id = (int)com.ExecuteNonQuery();
                        com = new SqlCommand(query2, con);
                        com.Parameters.AddWithValue("message", _Message);
                        com.Parameters.AddWithValue("title", _Title);
                        com.Parameters.AddWithValue("date", DateTime.Now);
                        com.Parameters.AddWithValue("username", Context.User.Identity.GetUserName());
                        id = (int)com.ExecuteNonQuery();
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
                        // Nu o lasam deschisa.
                        con.Close();
                        Response.Redirect(String.Format("~/Group.aspx?t={0}", t));
                    }
                }


            }
        }
    }
}