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

namespace InternHub.intern
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
                        string query = "select * from tblIntern where email=@email";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@email", Session["email"].ToString());
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtInternName.Text = Server.HtmlDecode(reader["name"].ToString());
                                txtInternTitle.Text = Server.HtmlDecode(reader["title"].ToString());

                                if (reader["image"].ToString().Length == 0)
                                    internPhoto.ImageUrl = "/intern/assests/images/DefaultProfilePic.png";

                                else
                                {
                                    internPhoto.ImageUrl = "/intern/assests/uploads/photos/" + reader["image"].ToString();
                                    photoFileName.Value = reader["image"].ToString();
                                }

                                txtInternSkills.Text = Server.HtmlDecode(reader["skills"].ToString());
                                txtInternQualifications.Text = Server.HtmlDecode(reader["qualifications"].ToString());

                                txtInternPortfolio.Text = reader["portfolio"].ToString();

                                if (reader["resume"].ToString().Length > 0)
                                {
                                    internResume.NavigateUrl = "/intern/assests/uploads/resumes/" + reader["resume"].ToString();
                                    resumeFileName.Value = reader["resume"].ToString();
                                }

                                else
                                {
                                    internResume.Text = "No Resume";
                                    internResume.Enabled = false;
                                }

                                txtInternPhone.Text = reader["phone"].ToString();
                                txtInternAddress.Text = Server.HtmlDecode(reader["address"].ToString());
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
                    filePhoto.SaveAs(Server.MapPath("/intern/assests/uploads/photos/" + fileName + DT.ToString().Replace(':', '-').Replace('/', '-').Replace('\\', '-') + fileExtension));
                    photoLabel.Text = "File uploaded!";
                    photoLabel.ForeColor = System.Drawing.Color.Green;
                    photoFileName.Value = fileName + DT.ToString().Replace(':', '-').Replace('/', '-').Replace('\\', '-') + fileExtension;
                    internPhoto.ImageUrl = "/intern/assests/uploads/photos/" + photoFileName.Value;
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

        protected void btnResumeUpload_Click(object sender, EventArgs e)
        {

            string fileName = Path.GetFileNameWithoutExtension(fileResume.FileName);
            string fileExtension = Path.GetExtension(fileResume.FileName);
            DateTime DT = DateTime.Now;

            if (fileExtension == ".pdf")
            {
                int fileSize = fileResume.PostedFile.ContentLength;

                if (fileSize <= 2097152)
                {
                    fileResume.SaveAs(Server.MapPath("/intern/assests/uploads/resumes/" + fileName + DT.ToString().Replace(':', '-').Replace('/', '-').Replace('\\', '-') + fileExtension));
                    resumeLabel.Text = "File uploaded!";
                    resumeLabel.ForeColor = System.Drawing.Color.Green;
                    resumeFileName.Value = fileName + DT.ToString().Replace(':', '-').Replace('/', '-').Replace('\\', '-') + fileExtension;
                    internResume.Text = "View Resume";
                    internResume.NavigateUrl = "/intern/assests/uploads/resumes/" + resumeFileName.Value;
                }

                else
                {
                    resumeLabel.Text = "Max 2 MB files are allowed!";
                    resumeLabel.ForeColor = System.Drawing.Color.Red;
                }
            }

            else
            {
                resumeLabel.Text = "Only PDF files are allowed!";
                resumeLabel.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Page.IsValid && Page.IsPostBack)
            {
                string internName = Server.HtmlEncode(txtInternName.Text);
                string internPhoto = photoFileName.Value;
                string internAddress = Server.HtmlEncode(txtInternAddress.Text);
                string internPhone = Server.HtmlEncode(txtInternPhone.Text);
                string internTitle = Server.HtmlEncode(txtInternTitle.Text);
                string internPortfolio = Server.HtmlEncode(txtInternPortfolio.Text);
                string internSkills = Server.HtmlEncode(txtInternSkills.Text);
                string internQualifications = Server.HtmlEncode(txtInternQualifications.Text);
                string internResume = resumeFileName.Value;

                string CS = ConfigurationManager.ConnectionStrings["InternHubDB"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateInternProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter email = new SqlParameter("@email", Session["email"].ToString());
                    SqlParameter name = new SqlParameter("@name", internName);
                    SqlParameter title = new SqlParameter("@title", internTitle);
                    SqlParameter address = new SqlParameter("@address", internAddress);
                    SqlParameter phone = new SqlParameter("@phone", internPhone);
                    SqlParameter skills = new SqlParameter("@skills", internSkills);
                    SqlParameter qualifications = new SqlParameter("@qualifications", internQualifications);
                    SqlParameter portfolio = new SqlParameter("@portfolio", internPortfolio);
                    SqlParameter image = new SqlParameter("@image", internPhoto);
                    SqlParameter resume = new SqlParameter("@resume", internResume);

                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(title);
                    cmd.Parameters.Add(address);
                    cmd.Parameters.Add(phone);
                    cmd.Parameters.Add(skills);
                    cmd.Parameters.Add(qualifications);
                    cmd.Parameters.Add(portfolio);
                    cmd.Parameters.Add(image);
                    cmd.Parameters.Add(resume);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }

                Response.Redirect("~/intern/dashboard");

            }

        }
    }
}