using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace InternHub.organisation
{
    public partial class ViewIntern : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
                Response.Redirect("~/organisation/InternshipApplications");

            else
            {
                string skills = "";
                string qualifications = "";
                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = $"select * from tblIntern where id={Request.QueryString["id"]}";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            internName.Text = Server.HtmlDecode(reader["name"].ToString());
                            internTitle.Text = Server.HtmlDecode(reader["title"].ToString());
                            internPhoto.ImageUrl = "~/intern/assests/uploads/photos/" + reader["image"].ToString();

                            skills = Server.HtmlDecode(reader["skills"].ToString());
                            qualifications = Server.HtmlDecode(reader["qualifications"].ToString());

                            internPortfolio.NavigateUrl = reader["portfolio"].ToString();
                            internResume.NavigateUrl = "~/intern/assests/uploads/resumes/" + reader["resume"].ToString();

                            intern_email.Text = reader["email"].ToString();
                            intern_email.NavigateUrl = "mailto:" + reader["email"].ToString();
                            intern_phone.Text = reader["phone"].ToString();
                            intern_phone.NavigateUrl = "tel:" + reader["phone"].ToString();
                            internAddress.Text = Server.HtmlDecode(reader["address"].ToString());
                        }
                        con.Close();
                    }
                }

                Page.Title = internName.Text + " | InternHub";

                string[] skillsArray = skills.Split(',');
                for (int i = 0; i < skillsArray.Length; i++)
                {
                    Label newLabel = new Label();
                    internSkills.Controls.Add(newLabel);
                    newLabel.Text = skillsArray[i].ToString();
                }

                string[] qualificationsArray = qualifications.Split(',');
                for (int i = 0; i < qualificationsArray.Length; i++)
                {
                    Label newLabel = new Label();
                    internQualifications.Controls.Add(newLabel);
                    newLabel.Text = qualificationsArray[i].ToString();

                }
            }

        }
    }
}