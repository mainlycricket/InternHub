using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace InternHub
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                string enteredEmail = userEmail.Text;
                string enteredPassword = userPassword.Text;
                string encryptedPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(enteredPassword, "SHA1");

                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter email = new SqlParameter("@email", enteredEmail);
                    SqlParameter password = new SqlParameter("@password", encryptedPassword);

                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(password);

                    con.Open();
                    int RetunCode = (int)cmd.ExecuteScalar();

                    if (RetunCode == -1)
                    {
                        formResposnse.ForeColor = System.Drawing.Color.Red;
                        formResposnse.Text = "Invalid credentials!";
                    }

                    else
                    {
                        formResposnse.ForeColor = System.Drawing.Color.Green;
                        formResposnse.Text = "Logged in!";

                        SqlCommand cmd2 = new SqlCommand("spGetRole", con);
                        cmd2.CommandType = CommandType.StoredProcedure;

                        SqlParameter email2 = new SqlParameter("@email", enteredEmail);
                        cmd2.Parameters.Add(email2);

                        string role = cmd2.ExecuteScalar().ToString();

                        Session["role"] = role;

                        Session["email"] = enteredEmail;

                        if (role == "intern")
                        {
                            Response.Redirect("~/intern/dashboard.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/organisation/dashboard.aspx");
                        }

                    }

                }

            }

            else
            {
                formResposnse.ForeColor = System.Drawing.Color.Red;
                formResposnse.Text = "Invalid";
            }


        }

    }
}