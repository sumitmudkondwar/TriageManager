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
    public partial class TriageCalender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridDataBind();
        }

        private void GridDataBind()
        {
            DataTable dt = new DataTable();

            TriagePollLogic triagePollLogic = new TriagePollLogic();
            dt = triagePollLogic.GetTriageCalender();
            grdTriageCalender.DataSource = dt;
            grdTriageCalender.DataBind();

            //return ds;
        }
    }
}