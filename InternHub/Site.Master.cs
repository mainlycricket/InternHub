using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternHub
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                btn_login.InnerText = "Dashboard";
                if (Session["role"].ToString() == "intern")
                    btn_login.Attributes["href"] = "~/intern/dashboard";
                else
                    btn_login.Attributes["href"] = "~/organisation/dashboard";
            }
        }
    }
}