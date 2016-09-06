using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.BusinessLogic;
using System.Data;

namespace TriageManager.Triage
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateDropdownlist();
            }
        }

        private void PopulateDropdownlist()
        {
            DataTable dt = new DataTable();
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            dt = triagePollLogic.GetReportDates(HttpContext.Current.User.Identity.Name.ToString());

            ddlTriageDates.DataTextField = "TriageDate";
            ddlTriageDates.DataValueField = "TriageDate";
            
            ddlTriageDates.DataSource = dt;
            ddlTriageDates.DataBind();
        }

        protected void ddlTriageDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            grdReport.DataSource = triagePollLogic.GetReportData(HttpContext.Current.User.Identity.Name.ToString(), ddlTriageDates.SelectedValue.ToString());
            grdReport.DataBind();
        }
    }
}