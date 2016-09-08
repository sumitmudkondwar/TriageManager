using DataAccessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TriageManager.Triage
{
    public partial class FeedBackPending : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            grdFeedBackPending.DataSource = triagePollLogic.GetFeedBackPending(HttpContext.Current.User.Identity.Name.ToString());
            grdFeedBackPending.DataBind();
        }
    }
}