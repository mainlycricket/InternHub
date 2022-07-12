using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace InternHub.organisation
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || Session["role"].ToString() != "organisation")
            {
                Response.Redirect("../Login");
            }
            else
            {
                string userEmail = Session["email"].ToString();
                string role = Session["role"].ToString();

                DataTable tblInternships = new DataTable();
                tblInternships.Columns.AddRange(new DataColumn[8]
                {
                    new DataColumn("internship_id"),
                    new DataColumn("row_id"),
                    new DataColumn("job_title"),
                    new DataColumn("stream"),
                    new DataColumn("closing_date"),
                    new DataColumn("openings"),
                    new DataColumn("pending_applications"),
                    new DataColumn("confirmed_interns")
                });

                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {

                    int row_id = 0;
                    int internship_id = 0;
                    string job_title = "";
                    string stream = "";
                    string closing_date = "";
                    int openings = 0;
                    string pending_applications = "";
                    string confirmed_interns = "";
                    

                    string query = $"SELECT * from tblInternships where organisation='{Session["email"]}'";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int count_pending = 0;
                            int count_confirmed = 0;

                            row_id += 1;
                            internship_id = Convert.ToInt32(reader["id"]);
                            job_title = reader["job_title"].ToString();
                            stream = reader["stream"].ToString().ToUpper();
                            closing_date = Convert.ToDateTime(reader["closing_date"]).ToString("d-MMM-yyyy");
                            openings = Convert.ToInt32(reader["openings"].ToString());
                            pending_applications = reader["applicants"].ToString();
                            confirmed_interns = reader["confirmed_interns"].ToString();

                            string[] listPendingApplications = pending_applications.Split(',');
                            foreach (string app in listPendingApplications)
                            {
                                if (!string.IsNullOrEmpty(app))
                                    count_pending += 1;
                            }

                            string[] listConfirmedApplications = confirmed_interns.Split(',');
                            foreach (string app in listConfirmedApplications)
                            {
                                if (!string.IsNullOrEmpty(app))
                                    count_confirmed += 1;
                            }

                            tblInternships.Rows.Add(internship_id, row_id, job_title, stream, closing_date, openings, count_pending, count_confirmed);

                        }
                    }

                }

                orgInternships.DataSource = tblInternships;
                orgInternships.DataBind();

            }
        }

        protected void btnActionInternship (object sender, CommandEventArgs e)
        {
            int internship_id = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case "Edit":
                    Response.Redirect($"~/organisation/EditInternship?id={internship_id}");
                    break;

                case "Delete":
                    string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        string query = $"DELETE from tblInternships where id={internship_id}";
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Redirect("~/organisation/dashboard");
                    }
                    break;
            }

        }

    }
}