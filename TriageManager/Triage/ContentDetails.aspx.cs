using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TriageManager.Triage
{
    public partial class ContentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string GUID = Request["GUID"].ToString();
            lblTopic.Text = Request["ContentHeading"].ToString();


        }
    }
}