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
                lblMessage.Text = string.Empty;
                PopulateDropdownlist();
            }
        }

        private void PopulateDropdownlist()
        {
            DataTable dt = new DataTable();
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            string Designation = string.Empty;

            dt = triagePollLogic.GetReportNameList(HttpContext.Current.User.Identity.Name.ToString(), out Designation);

            Session["Designation"] = Designation;

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
                if (dt.Rows.Count == 0)
                {
                    lblMessage.Text = "No Records Found...";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblMessage.Text = "Total Records: " + dt.Rows.Count.ToString();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void btnGetReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            dt = triagePollLogic.GetReportData(ddlTriageDates.SelectedValue.ToString(), ddlReportType.SelectedValue.ToString(), Session["Designation"].ToString());

            grdReport.DataSource = dt;
            grdReport.DataBind();

            if (dt.Rows.Count == 0)
            {
                lblMessage.Text = "No Records Found...";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblMessage.Text = "Total Records: " + dt.Rows.Count.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
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

            lblMessage.Text = string.Empty;
        }
    }
}