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
    public partial class InternshipApplications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || Session["role"].ToString() != "organisation")
            {
                Response.Redirect("../Login");
            }


            else
            {

                DataTable tblApplicants = new DataTable();
                tblApplicants.Columns.AddRange(new DataColumn[9] {
                    new DataColumn("row_id"),
                    new DataColumn("internshipId"),
                    new DataColumn("ApplicantId"),
                    new DataColumn("internshipCol"),
                    new DataColumn("stream"),
                    new DataColumn("ApplicantCol"),
                    new DataColumn("PortfolioCol"),
                    new DataColumn("ResumeCol"),
                    new DataColumn("ProfileCol")
                });

                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;

                string job_title = "";
                string stream = "";
                string applicants = "";
                string applicant_name = "";
                string applicant_resume = "";
                string applicant_portfolio = "";
                string applicant_profile = "";
                int internshipId = 0;
                int row_id = 0;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "SELECT id, job_title, stream, applicants from tblInternships where organisation=@email";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@email", Session["email"].ToString());
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            internshipId = Convert.ToInt32(reader["id"]);
                            job_title = reader["job_title"].ToString();
                            stream = reader["stream"].ToString();
                            applicants = reader["applicants"].ToString();
                            if (applicants.Length > 0)
                            {
                                string[] applicantsList = applicants.Split(',');
                                foreach (string applicant in applicantsList)
                                {
                                    query = $"SELECT * from tblIntern where id={applicant}";
                                    SqlCommand cmd2 = new SqlCommand(query, con);
                                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                                    {
                                        while (reader2.Read())
                                        {
                                            row_id += 1;
                                            applicant_name = reader2["name"].ToString();
                                            applicant_portfolio = reader2["portfolio"].ToString();
                                            applicant_resume = reader2["resume"].ToString();
                                            applicant_profile = applicant;

                                            tblApplicants.Rows.Add(row_id, internshipId, applicant, job_title, stream, applicant_name, applicant_portfolio, applicant_resume, applicant_profile);

                                        }
                                    }
                                }
                            }


                        }
                    }
                }


                GridViewApplicants.DataSource = tblApplicants;
                GridViewApplicants.DataBind();

            }
        }

        protected void btnActionApplication(object sender, CommandEventArgs e)
        {
            // CommandArgument = applicantId-internshipId
            string[] cmdArguments = e.CommandArgument.ToString().Split('-');
            int applicantId = Convert.ToInt32(cmdArguments[0]);
            int internshipId = Convert.ToInt32(cmdArguments[1]);

            switch (e.CommandName)
            {

                case "Accept":

                    string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(CS))
                    {

                        string applied_internships = "";    // can't be null
                        string confirmed_internships = "";
                        string applicants = "";     // can't be null
                        string confirmed_interns = "";
                        int openings = 0;

                        string query = $"SELECT confirmed_internships, applied_internships from tblIntern where id={applicantId}";
                        SqlCommand sqlCommand = new SqlCommand(query, conn);
                        conn.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                confirmed_internships = reader["confirmed_internships"].ToString();
                                applied_internships = reader["applied_internships"].ToString();
                            }
                        }

                        query = $"SELECT applicants, openings, confirmed_interns from tblInternships where id={internshipId}";
                        SqlCommand sqlCommand2 = new SqlCommand(query, conn);

                        using (SqlDataReader reader2 = sqlCommand2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                applicants = reader2["applicants"].ToString();
                                confirmed_interns = reader2["confirmed_interns"].ToString();
                                openings = Convert.ToInt32(reader2["openings"]);
                            }
                        }

                        string[] arrAppliedInternships = applied_internships.Split(',');
                        arrAppliedInternships = arrAppliedInternships.Where(val => val != internshipId.ToString()).ToArray();
                        string updatedAppliedInternships = string.Join(",", arrAppliedInternships);

                        string[] arrApplicants = applicants.Split(',');
                        arrApplicants = arrApplicants.Where(val => val != applicantId.ToString()).ToArray();
                        string updatedApplicants = string.Join(",", arrApplicants);

                        if (string.IsNullOrEmpty(confirmed_internships))
                            confirmed_internships = internshipId.ToString();

                        else
                            confirmed_internships += "," + internshipId.ToString();

                        if (string.IsNullOrEmpty(confirmed_interns))
                            confirmed_interns = applicantId.ToString();

                        else
                            confirmed_interns += "," + applicantId.ToString();

                        openings -= 1;

                        SqlCommand cmd3 = new SqlCommand("spAcceptInternApplication", conn);
                        cmd3.CommandType = CommandType.StoredProcedure;

                        cmd3.Parameters.Add(new SqlParameter("@intern_id", applicantId));
                        cmd3.Parameters.Add(new SqlParameter("@internship_id", internshipId));
                        cmd3.Parameters.Add(new SqlParameter("@applied_internships", updatedAppliedInternships));
                        cmd3.Parameters.Add(new SqlParameter("@confirmed_internships", confirmed_internships));
                        cmd3.Parameters.Add(new SqlParameter("@applicants", updatedApplicants));
                        cmd3.Parameters.Add(new SqlParameter("@confirmed_interns", confirmed_interns));
                        cmd3.Parameters.Add(new SqlParameter("@openings", openings));
                        cmd3.ExecuteNonQuery();

                        Response.Redirect("~/organisation/dashboard");

                    }

                    break;

                case "Reject":

                    CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(CS))
                    {

                        string applied_internships = "";    // can't be null
                        string rejected_internships = "";
                        string applicants = "";     // can't be null
                        string rejected_interns = "";

                        string query = $"SELECT rejected_internships, applied_internships from tblIntern where id={applicantId}";
                        SqlCommand sqlCommand = new SqlCommand(query, conn);
                        conn.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                rejected_internships = reader["rejected_internships"].ToString();
                                applied_internships = reader["applied_internships"].ToString();
                            }
                        }

                        query = $"SELECT applicants, rejected_interns from tblInternships where id={internshipId}";
                        SqlCommand sqlCommand2 = new SqlCommand(query, conn);

                        using (SqlDataReader reader2 = sqlCommand2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                applicants = reader2["applicants"].ToString();
                                rejected_interns = reader2["rejected_interns"].ToString();
                            }
                        }

                        string[] arrAppliedInternships = applied_internships.Split(',');
                        arrAppliedInternships = arrAppliedInternships.Where(val => val != internshipId.ToString()).ToArray();
                        string updatedAppliedInternships = string.Join(",", arrAppliedInternships);

                        string[] arrApplicants = applicants.Split(',');
                        arrApplicants = arrApplicants.Where(val => val != applicantId.ToString()).ToArray();
                        string updatedApplicants = string.Join(",", arrApplicants);

                        if (string.IsNullOrEmpty(rejected_internships))
                            rejected_internships = internshipId.ToString();

                        else
                            rejected_internships += "," + internshipId.ToString();

                        if (string.IsNullOrEmpty(rejected_interns))
                            rejected_interns = applicantId.ToString();

                        else
                            rejected_interns += "," + applicantId.ToString();

                        SqlCommand cmd3 = new SqlCommand("spRejectInternApplication", conn);
                        cmd3.CommandType = CommandType.StoredProcedure;

                        cmd3.Parameters.Add(new SqlParameter("@intern_id", applicantId));
                        cmd3.Parameters.Add(new SqlParameter("@internship_id", internshipId));
                        cmd3.Parameters.Add(new SqlParameter("@applied_internships", updatedAppliedInternships));
                        cmd3.Parameters.Add(new SqlParameter("@rejected_internships", rejected_internships));
                        cmd3.Parameters.Add(new SqlParameter("@applicants", updatedApplicants));
                        cmd3.Parameters.Add(new SqlParameter("@rejected_interns", rejected_interns));
                        cmd3.ExecuteNonQuery();

                        Response.Redirect("~/organisation/dashboard");

                    }

                    break;

            }
        }
    }
}