using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.BusinessLogic;

namespace TriageManager
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            grdDashboard.DataSource = triagePollLogic.GetDashboardData();
            grdDashboard.DataBind();
        }
    }
}