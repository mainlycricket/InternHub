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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        protected void btnRegistser_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                string enteredEmail = userEmail.Text;
                string enteredPassword = userPassword.Text;
                string encryptedPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(enteredPassword, "SHA1");
                string enteredRole = userRoleSelect.Text;

                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter email = new SqlParameter("@email", enteredEmail);
                    SqlParameter password = new SqlParameter("@password", encryptedPassword);
                    SqlParameter role = new SqlParameter("@role", enteredRole);

                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(password);
                    cmd.Parameters.Add(role);

                    con.Open();
                    int RetunCode = (int)cmd.ExecuteScalar();

                    if (RetunCode == -1)
                    {
                        formResposnse.ForeColor = System.Drawing.Color.Red;
                        formResposnse.Text = "User already exists!";
                    }

                    else
                    {

                        if (enteredRole == "intern")
                        {
                            SqlCommand cmd2 = new SqlCommand("spRegisterIntern", con);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            SqlParameter email2 = new SqlParameter("@email", enteredEmail);
                            cmd2.Parameters.Add(email2);
                            cmd2.ExecuteNonQuery();

                            Response.Redirect("~/Login");
                        }

                        else if (enteredRole == "organisation")
                        {
                            SqlCommand cmd2 = new SqlCommand("spRegisterOrg", con);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            SqlParameter email2 = new SqlParameter("@email", enteredEmail);
                            cmd2.Parameters.Add(email2);
                            cmd2.ExecuteNonQuery();

                            Response.Redirect("~/Login");
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