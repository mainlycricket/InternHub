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
    public partial class ViewOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
                Response.Redirect("~/");

            else
            {

                int orgId = Convert.ToInt32(Request.QueryString["id"]);

                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = $"SELECT * from tblOrganisation where id={orgId}";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orgName.Text = reader["name"].ToString();
                            orgStream.Text = reader["stream"].ToString();

                            org_email.Text = reader["email"].ToString();
                            org_email.NavigateUrl = "mailto:" + org_email.Text;

                            orgLink.NavigateUrl = reader["link"].ToString();

                            org_phone.Text = reader["phone"].ToString();
                            org_phone.NavigateUrl = "tel:" + org_phone.Text;

                            orgAddress.Text = reader["address"].ToString();

                            if (string.IsNullOrEmpty(reader["logo"].ToString()))
                                orgLogo.ImageUrl = "~/intern/assests/images/DefaultProfilePic.png";

                            else
                                orgLogo.ImageUrl = "~/organisation/assests/uploads/" + reader["logo"].ToString();

                        }
                    }
                }

            }
        }
    }
}