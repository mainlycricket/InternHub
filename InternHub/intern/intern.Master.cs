using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternHub.intern
{
    public partial class intern : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           greet.Text = Session["email"].ToString();
        }
    }
}