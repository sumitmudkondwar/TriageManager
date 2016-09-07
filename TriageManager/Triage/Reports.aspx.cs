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
            dt = triagePollLogic.GetReportNameList("sumudk@microsoft.com");//HttpContext.Current.User.Identity.Name.ToString());

            if (dt != null)
            {
                dvSelectEngineer.Visible = true;
                ddlEngineerName.DataTextField = "Name";
                ddlEngineerName.DataValueField = "Alias";

                ddlEngineerName.DataSource = dt;
                ddlEngineerName.DataBind();
            }
            else
            {
                dt = new DataTable();
                dvSelectEngineer.Visible = false;
                dt = triagePollLogic.GetReportDataForAll(HttpContext.Current.User.Identity.Name.ToString());
                grdReport.DataSource = dt;
                grdReport.DataBind();
            }
        }

        protected void btnGetReport_Click(object sender, EventArgs e)
        {
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            grdReport.DataSource = triagePollLogic.GetReportData(ddlTriageDates.SelectedValue.ToString(), ddlReportType.SelectedValue.ToString());
            grdReport.DataBind();
        }

        protected void ddlEngineerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            dt = triagePollLogic.GetTriageDateList(ddlEngineerName.SelectedValue);

            ddlTriageDates.DataTextField = "TriageDate";
            ddlTriageDates.DataValueField = "TriageDate";

            ddlTriageDates.DataSource = dt;
            ddlTriageDates.DataBind();

            grdReport.DataSource = null;
            grdReport.DataBind();

        }
    }
}