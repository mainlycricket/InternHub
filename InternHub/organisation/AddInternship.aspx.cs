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
    public partial class AddInternship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || Session["role"].ToString() != "organisation")
            {
                Response.Redirect("../Login");
            }
        }

        protected void btnAddInternship_Click(object sender, EventArgs e)
        {

            string internshipTitle = Server.HtmlEncode(txtInternshipTitle.Text);
            string internshipStream = DropDownListStream.Text.ToLower();
            string internshipQualification = Server.HtmlEncode(txtInternshipQualification.Text);
            string internshipRequirements = Server.HtmlEncode(txtInternshipRequirements.Text);
            string internshipResponsibilities = Server.HtmlEncode(txtInternshipResponsibilites.Text);
            string internshipLocation = Server.HtmlEncode(txtInternshipLocation.Text);
            string closingDate = internshipClosingDate.Text;
            string internshipOrg = Session["email"].ToString();
            string WFH = "";
            string trainee = "";

            int openingsCount = Convert.ToInt32(internshipOpeningsCount.Text);
            int minSalary = Convert.ToInt32(internshipMinSalary.Text);
            int maxSalary = Convert.ToInt32(internshipMaxSalary.Text);
            int internshipDuration = Convert.ToInt32(txtInternshipDuration.Text);

            DateTime internshipPostedDate = DateTime.Now.Date;

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
                SqlCommand cmd = new SqlCommand("spAddInternship", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@organisation", internshipOrg));
                cmd.Parameters.Add(new SqlParameter("@date_posted", internshipPostedDate));
                cmd.Parameters.Add(new SqlParameter("@job_title", internshipTitle));
                cmd.Parameters.Add(new SqlParameter("@stream", internshipStream));
                cmd.Parameters.Add(new SqlParameter("@min_qualification", internshipQualification));
                cmd.Parameters.Add(new SqlParameter("@requirements", internshipRequirements));
                cmd.Parameters.Add(new SqlParameter("@responsibilites", internshipResponsibilities));
                cmd.Parameters.Add(new SqlParameter("@isWFH", WFH));
                cmd.Parameters.Add(new SqlParameter("@is_trainne", trainee));
                cmd.Parameters.Add(new SqlParameter("@closing_date", closingDate));
                cmd.Parameters.Add(new SqlParameter("@location", internshipLocation));
                cmd.Parameters.Add(new SqlParameter("@duration", internshipDuration));
                cmd.Parameters.Add(new SqlParameter("@openings", openingsCount));
                cmd.Parameters.Add(new SqlParameter("@salary_min", minSalary));
                cmd.Parameters.Add(new SqlParameter("@salary_max", maxSalary));

                con.Open();
                cmd.ExecuteNonQuery();

                Response.Redirect("dashboard");

            }
        }
    }
}