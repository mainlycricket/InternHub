using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InternHub.intern
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || Session["role"].ToString() != "intern")
            {
                Response.Redirect("../Login");
            }

            else
            {
                string userEmail = Session["email"].ToString();
                string role = Session["role"].ToString();
                //greet.Text = "Hello, " + userEmail + " - " + role;

                if (ViewState["applyInternshipWarning"] != null)
                {
                    warning.Text = "Warning";
                }

                else
                {
                    warning.Text = "No warning";
                }

                DataTable tblInternships = new DataTable();
                tblInternships.Columns.AddRange(new DataColumn[8]
                {
                    new DataColumn("internship_id"),
                    new DataColumn("row_id"),
                    new DataColumn("job_title"),
                    new DataColumn("stream"),
                    new DataColumn("org_name"),
                    new DataColumn("org_id"),
                    new DataColumn("org_email"),
                    new DataColumn("status")
                });

                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    int row_id = 0;
                    string job_title = "";
                    string stream = "";
                    string org_email = "";
                    string org_id = "";
                    string org_name = "";
                    string query = $"SELECT applied_internships, confirmed_internships, rejected_internships from tblIntern where email='{Session["email"]}'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string appliedInternships = reader["applied_internships"].ToString();
                            if (! string.IsNullOrEmpty(appliedInternships))
                            {
                                string[] listAppliedInternships = appliedInternships.Split(',');
                                foreach (string appliedInternship in listAppliedInternships)
                                {
                                    int applied_internship = Convert.ToInt32(appliedInternship);
                                    row_id += 1;
                                    query = $"select job_title, tblInternships.stream as stream, organisation, tblOrganisation.id as org_id, [name] from tblInternships INNER JOIN tblOrganisation ON tblInternships.organisation = tblOrganisation.email where tblInternships.id = {applied_internship}";
                                    
                                    SqlCommand cmd2 = new SqlCommand(query, con);
                                    
                                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                                    {
                                        while (reader2.Read())
                                        {
                                            job_title = reader2["job_title"].ToString();
                                            stream = reader2["stream"].ToString();
                                            org_email = reader2["organisation"].ToString();
                                            org_id = reader2["org_id"].ToString();
                                            org_name = reader2["name"].ToString();
                                        }
                                    }

                                    string status = "Pending";

                                    tblInternships.Rows.Add(appliedInternship, row_id, job_title, stream, org_name, org_id, org_email, status);
                                }
                            }

                            string confirmedInternships = reader["confirmed_internships"].ToString();
                            if (! string.IsNullOrEmpty(confirmedInternships))
                            {
                                string[] listConfirmedInternships = confirmedInternships.Split(',');
                                foreach (string confirmedInternship in listConfirmedInternships)
                                {
                                    int confirmed_internship = Convert.ToInt32(confirmedInternship);
                                    row_id += 1;
                                    query = $"select job_title, tblInternships.stream as stream, organisation, tblOrganisation.id as org_id, [name] from tblInternships INNER JOIN tblOrganisation ON tblInternships.organisation = tblOrganisation.email where tblInternships.id = {confirmed_internship}";

                                    SqlCommand cmd2 = new SqlCommand(query, con);

                                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                                    {
                                        while (reader2.Read())
                                        {
                                            job_title = reader2["job_title"].ToString();
                                            stream = reader2["stream"].ToString();
                                            org_email = reader2["organisation"].ToString();
                                            org_id = reader2["org_id"].ToString();
                                            org_name = reader2["name"].ToString();
                                        }
                                    }

                                    string status = "Confirmed";

                                    tblInternships.Rows.Add(confirmedInternship, row_id, job_title, stream, org_name, org_id, org_email, status);
                                }
                            }

                            string rejectedInternships = reader["rejected_internships"].ToString();
                            if (!string.IsNullOrEmpty(rejectedInternships))
                            {
                                string[] listRejectedInternships = rejectedInternships.Split(',');
                                foreach (string rejectedInternship in listRejectedInternships)
                                {
                                    int rejected_internship = Convert.ToInt32(rejectedInternship);
                                    row_id += 1;
                                    query = $"select job_title, tblInternships.stream as stream, organisation, tblOrganisation.id as org_id, [name] from tblInternships INNER JOIN tblOrganisation ON tblInternships.organisation = tblOrganisation.email where tblInternships.id = {rejected_internship}";

                                    SqlCommand cmd2 = new SqlCommand(query, con);

                                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                                    {
                                        while (reader2.Read())
                                        {
                                            job_title = reader2["job_title"].ToString();
                                            stream = reader2["stream"].ToString();
                                            org_email = reader2["organisation"].ToString();
                                            org_id = reader2["org_id"].ToString();
                                            org_name = reader2["name"].ToString();
                                        }
                                    }

                                    string status = "Rejected";

                                    tblInternships.Rows.Add(rejectedInternship, row_id, job_title, stream, org_name, org_id, org_email, status);
                                }
                            }

                        }

                    }

                }

                internInternships.DataSource = tblInternships;
                internInternships.DataBind();

            }
        }
    }

}
