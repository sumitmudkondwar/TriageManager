using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.BusinessLogic;
using System.Data;

namespace TriageManager
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            DataTable dt = triagePollLogic.GetFeedBackPending(HttpContext.Current.User.Identity.Name.ToString());
            if(dt.Rows.Count > 0)
                dvFeedBackPending.Visible = true;
            else
                dvFeedBackPending.Visible = false;

            grdDashboard.DataSource = triagePollLogic.GetDashboardData();
            grdDashboard.DataBind();
        }
    }
}