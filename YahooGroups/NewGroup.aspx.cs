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
    public partial class NewGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddGroup(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                bool valid = true;

                string _Name = Name.Text;
                string _Description = Description.Text;
                string _Email = Email.Text;
                string _Category = Category.Text;

                // TODO: Verificarea tuturor stringurilor de mai sus sau adaugarea validarilor in frontend
                if (_Name == "")
                {
                    valid = false;
                    Response.Write("Eroare: Numele nu poate fi gol");
                }

                if (valid)
                {
                    string query = "INSERT INTO  groups(name, description, email, category)  "
                       + " VALUES ( @name, @description, @email, @category)";
                    string query2= "INSERT INTO  GroupMembers  "
                       + " VALUES ( @username, @group, @moderator)";
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
                    con.Open();
                    try
                    {
                        // Introducem parametrii in cererea SQL
                        SqlCommand com = new SqlCommand(query, con);
                        // primul parametru, nume, este din query reprezentat de @nume iar _Nume este valoarea variabilei din formular

                            com.Parameters.AddWithValue("name", _Name);
                           com.Parameters.AddWithValue("description", _Description);
                         com.Parameters.AddWithValue("email", _Email);
                          com.Parameters.AddWithValue("category", _Category);
                       
                        int id = (int)com.ExecuteNonQuery();
                        com = new SqlCommand(query2, con);
                        com.Parameters.AddWithValue("username", Context.User.Identity.GetUserName());
                        com.Parameters.AddWithValue("group", _Name);
                        com.Parameters.AddWithValue("moderator", 1);
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
                        Response.Redirect(String.Format("~/Group.aspx?t={0}", this.Name.Text));

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

    }
}