using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace YahooGroups
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Register(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                bool valid = true;

                string _Username = Username.Text;
                string _Password = Password.Text;
                

                // TODO: Verificarea tuturor stringurilor de mai sus sau adaugarea validarilor in frontend
                if (_Username == "" )
                {
                    valid = false;
                    Response.Write("Eroare: Numele nu poate fi gol");
                }
                 if (_Password == "")
                {
                    valid = false;
                    Response.Write("Eroare: Numele nu poate fi gol");
                }
                if (valid)
                {
                    string query = "INSERT INTO  users(username, password)  "
                       + " VALUES ( @username, @password)";

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\denis\Documents\Visual Studio 2015\Projects\YahooGroups\YahooGroups\App_Data\database.mdf';");
                    con.Open();
                    try
                    {
                        // Introducem parametrii in cererea SQL
                        SqlCommand com = new SqlCommand(query, con);
                        // primul parametru, nume, este din query reprezentat de @nume iar _Nume este valoarea variabilei din formular

                        com.Parameters.AddWithValue("username", _Username);
                        com.Parameters.AddWithValue("password", _Password);
                       
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
                        // Nu o lasam deschisa.
                        con.Close();
                    }
                }


            }
        }
    }
}