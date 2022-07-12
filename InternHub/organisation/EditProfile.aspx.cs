using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace InternHub.organisation
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["email"] == null)
                {
                    Response.Redirect("../Login");
                }

                else
                {
                    string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        string query = "select * from tblOrganisation where email=@email";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@email", Session["email"].ToString());
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtOrgName.Text = Server.HtmlDecode(reader["name"].ToString());
                                txtOrgStream.Text = Server.HtmlDecode(reader["stream"].ToString());

                                if (reader["logo"].ToString().Length == 0)
                                    orgPhoto.ImageUrl = "~/intern/assests/images/DefaultProfilePic.png";

                                else
                                    orgPhoto.ImageUrl = "~/organisation/assests/uploads/" + reader["logo"].ToString();


                                txtOrgLink.Text = reader["link"].ToString();

                                txtOrgPhone.Text = reader["phone"].ToString();

                                txtOrgAddress.Text = reader["address"].ToString();


                            }
                            con.Close();
                        }
                    }
                }
            }

        }

        protected void btnPhotoUpload_Click(object sender, EventArgs e)
        {

            string fileName = Path.GetFileNameWithoutExtension(filePhoto.FileName);
            string fileExtension = Path.GetExtension(filePhoto.FileName);
            DateTime DT = DateTime.Now;

            if (fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".jpeg")
            {
                int fileSize = filePhoto.PostedFile.ContentLength;

                if (fileSize <= 1048576)
                {
                    filePhoto.SaveAs(Server.MapPath("/organisation/assests/uploads/" + fileName + DT.ToString().Replace(':', '-').Replace('/', '-').Replace('\\', '-') + fileExtension));
                    photoLabel.Text = "File uploaded!";
                    photoLabel.ForeColor = System.Drawing.Color.Green;
                    photoFileName.Value = fileName + DT.ToString().Replace(':', '-').Replace('/', '-').Replace('\\', '-') + fileExtension;
                    orgPhoto.ImageUrl = "/organisation/assests/uploads/" + photoFileName.Value;
                }

                else
                {
                    photoLabel.Text = "Max 1 MB files are allowed!";
                    photoLabel.ForeColor = System.Drawing.Color.Red;
                }
            }

            else
            {
                photoLabel.Text = "Only PNG, JPG & JPEG files are allowed!";
                photoLabel.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Page.IsValid && Page.IsPostBack)
            {
                string orgName = Server.HtmlEncode(txtOrgName.Text);
                string orgPhoto = photoFileName.Value;
                string orgAddress = Server.HtmlEncode(txtOrgAddress.Text);
                string orgPhone = Server.HtmlEncode(txtOrgPhone.Text);
                string orgStream = Server.HtmlEncode(txtOrgStream.Text);
                string orgLink = Server.HtmlEncode(txtOrgLink.Text);

                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateOrgProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter email = new SqlParameter("@email", Session["email"].ToString());
                    SqlParameter name = new SqlParameter("@name", orgName);
                    SqlParameter stream = new SqlParameter("@stream", orgStream);
                    SqlParameter address = new SqlParameter("@address", orgAddress);
                    SqlParameter phone = new SqlParameter("@phone", orgPhone);
                    SqlParameter link = new SqlParameter("@link", orgLink);
                    SqlParameter logo = new SqlParameter("@logo", orgPhoto);

                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(stream);
                    cmd.Parameters.Add(address);
                    cmd.Parameters.Add(phone);
                    cmd.Parameters.Add(link);
                    cmd.Parameters.Add(logo);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }

                Response.Redirect("~/organisation/dashboard");

            }

        }
    }
}