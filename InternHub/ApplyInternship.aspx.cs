using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InternHub
{
    public partial class ApplyInternship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || Session["role"] == null || Session["role"].ToString() != "intern")
            {
                Response.Redirect("~/Login");
            }

            string internshipId = Request.QueryString["id"];

            if (string.IsNullOrEmpty(internshipId))
            {
                Response.Redirect("~/");
            }

            else
            {

                int internId = 0;
                string internAppliedInternships = "";
                string internConfirmedInternships = "";
                string internRejectedInternships = "";
                string internshipApplicants = "";

                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    // getting intern data
                    string query = $"select id, applied_internships, confirmed_internships, rejected_internships from tblIntern where email='{Session["email"]}'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            internId = Convert.ToInt32(reader["id"].ToString());
                            internAppliedInternships = reader["applied_internships"].ToString();
                            internConfirmedInternships = reader["confirmed_internships"].ToString();
                            internRejectedInternships = reader["rejected_internships"].ToString();
                        }

                    }

                    string[] arrAppliedInternships = internAppliedInternships.Split(',');
                    string[] arrConfirmedInternships = internConfirmedInternships.Split(',');
                    string[] arrRejectedInternships = internRejectedInternships.Split(',');

                    if (arrAppliedInternships.Contains(internshipId.ToString()) || arrConfirmedInternships.Contains(internshipId.ToString()) || arrRejectedInternships.Contains(internshipId.ToString()))
                    {
                        // ScriptManager.RegisterStaInternHub.intern.dashboard.
                        ViewState["applyInternshipWarning"] = "You have already applied";
                        goto RedirectDashboard;
                    }

                    query = $"select applicants from tblInternships where id={internshipId}";
                    SqlCommand cmd2 = new SqlCommand(query, con);
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                            internshipApplicants = reader["applicants"].ToString();
                    }

                }

                if (string.IsNullOrEmpty(internAppliedInternships))
                    internAppliedInternships += internshipId.ToString();

                else
                    internAppliedInternships += "," + internshipId;


                if (string.IsNullOrEmpty(internshipApplicants))
                    internshipApplicants += internId.ToString();

                else
                    internshipApplicants += "," + internId;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spApplyInternship", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@intern_email", Session["email"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@applied_internships", internAppliedInternships));
                    cmd.Parameters.Add(new SqlParameter("@internship_id", internshipId));
                    cmd.Parameters.Add(new SqlParameter("@applicants", internshipApplicants));

                    con.Open();
                    cmd.ExecuteNonQuery();

                }

            RedirectDashboard:
                Response.Redirect("~/intern/dashboard");

            }

        }
    }
}