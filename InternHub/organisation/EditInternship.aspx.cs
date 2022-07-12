using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InternHub.organisation
{
    public partial class EditInternship : System.Web.UI.Page
    {

        int internship_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["email"] == null)
            {
                Response.Redirect("~/Login");
            }

            else if(string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Response.Redirect("~/organisation/dashboard");
            }
            
            else
            {
                internship_id = Convert.ToInt32(Request.QueryString["id"]);

                if (! Page.IsPostBack)
                {

                    string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        string query = $"SELECT * from tblInternships where id={internship_id}";

                        SqlCommand cmd = new SqlCommand(query, con);

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                string org = reader["organisation"].ToString();

                                if (org != Session["email"].ToString())
                                    Response.Redirect("~/organisation/dashboard");

                                else
                                {

                                    txtInternshipTitle.Text = Server.HtmlDecode(reader["job_title"].ToString());

                                    query = "SELECT stream from tblStreams";

                                    SqlCommand cmd2 = new SqlCommand(query, con);
                                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                                        while (reader2.Read())
                                            if (reader2["stream"].ToString().ToLower() == reader["stream"].ToString())
                                                DropDownListStream.SelectedValue = reader2["stream"].ToString();

                                    txtInternshipQualification.Text = Server.HtmlDecode(reader["min_qualification"].ToString());
                                    txtInternshipRequirements.Text = Server.HtmlDecode(reader["requirements"].ToString());
                                    txtInternshipResponsibilites.Text = Server.HtmlDecode(reader["responsibilities"].ToString());

                                    if (reader["work_from_home"].ToString() == "yes")
                                        CheckBoxWFH.Checked = true;

                                    if (reader["is_trainee"].ToString() == "yes")
                                        CheckBoxTrainee.Checked = true;

                                    txtInternshipLocation.Text = Server.HtmlDecode(reader["location"].ToString());
                                    txtInternshipDuration.Text = reader["duration"].ToString();

                                    DateTime closingDate = new DateTime();
                                    closingDate = Convert.ToDateTime(reader["closing_date"].ToString());

                                    internshipClosingDate.Text = closingDate.Date.ToString("yyyy-MM-d");

                                    internshipOpeningsCount.Text = reader["openings"].ToString();
                                    internshipMinSalary.Text = reader["salary_min"].ToString();
                                    internshipMaxSalary.Text = reader["salary_max"].ToString();

                                }


                            }

                        }
                    }

                }

                

            }

        }


        protected void btnEditInternship_Click(object sender, EventArgs e)
        {

            if (Page.IsValid && Page.IsPostBack)
            {
                string internshipTitle = Server.HtmlEncode(txtInternshipTitle.Text);
                string internshipStream = DropDownListStream.Text.ToLower();
                string internshipQualification = Server.HtmlEncode(txtInternshipQualification.Text);
                string internshipRequirements = Server.HtmlEncode(txtInternshipRequirements.Text);
                string internshipResponsibilities = Server.HtmlEncode(txtInternshipResponsibilites.Text);
                string internshipLocation = Server.HtmlEncode(txtInternshipLocation.Text);
                string closingDate = internshipClosingDate.Text;
                string WFH = "";
                string trainee = "";

                int openingsCount = Convert.ToInt32(internshipOpeningsCount.Text);
                int minSalary = Convert.ToInt32(internshipMinSalary.Text);
                int maxSalary = Convert.ToInt32(internshipMaxSalary.Text);
                int internshipDuration = Convert.ToInt32(txtInternshipDuration.Text);

                if (CheckBoxWFH.Checked)
                    WFH = "yes";
                else
                    WFH = "no";

                if (CheckBoxTrainee.Checked)
                    trainee = "yes";
                else
                    trainee = "no";

                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateInternship", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@id", internship_id));
                    cmd.Parameters.Add(new SqlParameter("@job_title", internshipTitle));
                    cmd.Parameters.Add(new SqlParameter("@stream", internshipStream));
                    cmd.Parameters.Add(new SqlParameter("@min_qualification", internshipQualification));
                    cmd.Parameters.Add(new SqlParameter("@requirements", internshipRequirements));
                    cmd.Parameters.Add(new SqlParameter("@responsibilities", internshipResponsibilities));
                    cmd.Parameters.Add(new SqlParameter("@work_from_home", WFH));
                    cmd.Parameters.Add(new SqlParameter("@is_trainee", trainee));
                    cmd.Parameters.Add(new SqlParameter("@closing_date", closingDate));
                    cmd.Parameters.Add(new SqlParameter("@location", internshipLocation));
                    cmd.Parameters.Add(new SqlParameter("@duration", internshipDuration));
                    cmd.Parameters.Add(new SqlParameter("@openings", openingsCount));
                    cmd.Parameters.Add(new SqlParameter("@salary_min", minSalary));
                    cmd.Parameters.Add(new SqlParameter("@salary_max", maxSalary));

                    con.Open();
                    cmd.ExecuteNonQuery();

                    Response.Redirect("~/organisation/dashboard");

                }
            }

        }

    }
}