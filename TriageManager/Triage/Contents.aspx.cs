using DataAccessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TriageManager.Triage
{
    public partial class Contents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();

            TriagePollLogic triagePollLogic = new TriagePollLogic();
            dt = triagePollLogic.GetTriageContents();
            grdTriageCalender.DataSource = dt;
            grdTriageCalender.DataBind();
        }
    }
}