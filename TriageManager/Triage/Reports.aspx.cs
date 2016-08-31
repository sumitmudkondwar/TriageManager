using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.BusinessLogic;

namespace TriageManager.Triage
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            grdReport.DataSource = triagePollLogic.GetReportTriageAttended(HttpContext.Current.User.Identity.Name.ToString());
            grdReport.DataBind();
        }
    }
}