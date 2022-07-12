using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace InternHub
{
    public partial class ShowInternships : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string stream = Request.QueryString["stream"];
            if (string.IsNullOrEmpty(stream))
            {
                Response.Redirect("~/Default");
            }
            else
            {

                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    //string today_date = DateTime.Now.Date.ToShortDateString();
                    // DateTime current_date = DateTime.ParseExact(DateTime.Now.ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    string current_date = DateTime.Now.Date.ToString("yyyy-M-d");
                    string query = "SELECT tblInternships.id as internship_id, tblOrganisation.id as orgId, job_title, min_qualification, requirements, responsibilities, work_from_home, is_trainee, closing_date, [location], duration, salary_min, salary_max, [name] FROM tblInternships INNER JOIN tblOrganisation ON tblOrganisation.email = tblInternships.organisation where tblInternships.stream=@stream and openings > 0 and status='active' and closing_date >='" + current_date + "'";
                    SqlCommand cmd = new SqlCommand(query, con); 
                    cmd.Parameters.AddWithValue("@stream", stream.ToLower());
                    /*cmd.Parameters.AddWithValue("@closing_date", current_date);*/
                    con.Open();
                    int count = 0, org_id = 0;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = Convert.ToInt32(reader["internship_id"].ToString());
                            org_id = Convert.ToInt32(reader["orgId"].ToString());

                            Panel internshipPanel = new Panel();
                            internshipPanel.CssClass = "card";
                            internshipPanel.ID = stream + "-internship-" + count;
                            showInternshipPanel.Controls.Add(internshipPanel);

                            // string orgEmail = Server.HtmlDecode(reader["organisation"].ToString());

                            string orgName = reader["name"].ToString();

                            /*using (SqlCommand cmd2 = new SqlCommand("spGetOrgName", con))
                            {
                                cmd2.CommandType = CommandType.StoredProcedure;
                                SqlParameter email = new SqlParameter("@email", orgEmail);
                                cmd2.Parameters.Add(email);

                                orgName = cmd2.ExecuteScalar().ToString();
                            }*/


                            HtmlGenericControl jobTitle = new HtmlGenericControl("h3");
                            jobTitle.Attributes["class"] = "internshipTitle";
                            jobTitle.InnerHtml = Server.HtmlDecode(reader["job_title"].ToString()) + $" - <a class=\"company_name\" href=\"/ViewOrg?id={org_id}\" target=\"_blank\">" + orgName + "</a>";
                            internshipPanel.Controls.Add(jobTitle);

                            /* END JOB TITLE */

                            HtmlGenericControl jobQualification = new HtmlGenericControl("h5");
                            jobQualification.Attributes["class"] = "internshipQualification";
                            jobQualification.InnerHtml = "Minimum Qualification: <span style = \"color: #0950b6;\" >" + Server.HtmlDecode(reader["min_qualification"].ToString()) + "</span>";
                            internshipPanel.Controls.Add(jobQualification);

                            /* END QUALIFICATION */

                            string[] skills = Server.HtmlDecode(reader["requirements"].ToString()).Split(',');

                            HtmlGenericControl jobSkills = new HtmlGenericControl("div");
                            jobSkills.Attributes["class"] = "internshipSkills";
                            jobSkills.InnerHtml = "<h5>Required Skills:</h5>";
                            jobSkills.InnerHtml += "<div class=\"skillsList\">";

                            foreach (string skill in skills)
                                jobSkills.InnerHtml += "<span class=\"skillItem\">" + skill.Trim() + "</span> ";

                            jobSkills.InnerHtml += "</div>";
                            internshipPanel.Controls.Add(jobSkills);

                            /* END SKILLS */

                            string[] responsibilities = Server.HtmlDecode(reader["responsibilities"].ToString()).Split(',');

                            HtmlGenericControl jobRoles = new HtmlGenericControl("div");
                            jobRoles.Attributes["class"] = "intnernshipResponsibilities";
                            jobRoles.InnerHtml = "<h5>Responsibilities:</h5>";
                            jobRoles.InnerHtml += "<div class=\"responsibilitiesList\">";

                            foreach (string responsibility in responsibilities)
                                jobRoles.InnerHtml += "<span class=\"responsibilityItem\">" + responsibility.Trim() + "</span> ";

                            jobRoles.InnerHtml += "</div>";
                            internshipPanel.Controls.Add(jobRoles);

                            /* END RESPONSIBILIES */

                            HtmlGenericControl jobDuration = new HtmlGenericControl("h5");
                            jobDuration.Attributes["class"] = "internshipDuration";
                            jobDuration.InnerHtml = $"Duration: <span style=\"color: #0950b6;\">{reader["duration"]} months </span>";
                            internshipPanel.Controls.Add(jobDuration);

                            /* END DURATION */

                            HtmlGenericControl jobLocation = new HtmlGenericControl("h5");
                            jobLocation.Attributes["class"] = "internshipLocation";
                            jobLocation.InnerHtml = $"Location: <span style=\"color: #0950b6;\">{Server.HtmlDecode(reader["location"].ToString())}</span>";
                            internshipPanel.Controls.Add(jobLocation);

                            /* END LOCATION */

                            if (reader["work_from_home"].ToString() == "yes")
                            {
                                HtmlGenericControl jobWFH = new HtmlGenericControl("h5");
                                jobWFH.Attributes["class"] = "internshipWFH";
                                jobWFH.InnerHtml = $"Work from Home: &#x2705;";
                                internshipPanel.Controls.Add(jobWFH);
                            }

                            /* END WFH */

                            if (reader["is_trainee"].ToString() == "yes")
                            {
                                HtmlGenericControl jobTrainee = new HtmlGenericControl("h5");
                                jobTrainee.Attributes["class"] = "internshipTrainee";
                                jobTrainee.InnerHtml = $"For Trainees: &#x2705;";
                                internshipPanel.Controls.Add(jobTrainee);
                            }

                            /* END Trainees */

                            HtmlGenericControl jobSalary = new HtmlGenericControl("h5");
                            jobSalary.Attributes["class"] = "internshipSalary";
                            jobSalary.InnerHtml = $"Salary: <span style=\"color: #0950b6;\">&#x20b9; {reader["salary_min"]} - {reader["salary_max"]}</span>";
                            internshipPanel.Controls.Add(jobSalary);

                            /* END SALARY */

                            HtmlGenericControl jobLastDate = new HtmlGenericControl("h5");
                            string lastDate = Convert.ToDateTime(reader["closing_date"]).Date.ToString("dd-MMM-yyyy");
                            jobLastDate.Attributes["class"] = "internshipLastDate";
                            jobLastDate.InnerHtml = $"Last date to apply: <span style=\"color: #0950b6;\">{lastDate}</span>";
                            // jobLastDate.InnerHtml = $"Last date to apply: <span style=\"color: #0950b6;\">{reader["closing_date"].ToString().Split()[0]}</span>";
                            internshipPanel.Controls.Add(jobLastDate);

                            /* END CLOSING DATE */

                            HyperLink btnApplyJob = new HyperLink();
                            btnApplyJob.CssClass = "btn btn-danger";
                            btnApplyJob.ID = "btn-apply";
                            if (Session["email"] != null && Session["role"] != null && Session["role"].ToString() == "intern")
                            {
                                btnApplyJob.Text = "Apply for Job";
                                btnApplyJob.NavigateUrl = $"~/ApplyInternship?id={count}";
                            }

                            else
                            {
                                btnApplyJob.Text = "Login to apply";
                                btnApplyJob.Target = "_blank";
                                btnApplyJob.NavigateUrl = "~/Login";
                            }

                            internshipPanel.Controls.Add(btnApplyJob);

                        }
                    }
                }
            }
        }
    }
}