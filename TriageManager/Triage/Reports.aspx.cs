using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.BusinessLogic;
using System.Data;
using System.Text;

namespace TriageManager.Triage
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnSendMailforPollSubmit.Visible = false;
                lblErrorMessage.Text = string.Empty;
                btnSendMailforPollSubmit.Enabled = true;

                lblMessage.Text = string.Empty;
                PopulateDropdownlist();
            }
        }

        private void PopulateDropdownlist()
        {
            DataTable dt = new DataTable();
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            string Designation = string.Empty;

            //dt = triagePollLogic.GetReportNameList(HttpContext.Current.User.Identity.Name.ToString(), out Designation);
            dt = triagePollLogic.GetReportNameList("sumudk@microsoft.com", out Designation);

            Session["Designation"] = Designation;

            if (dt != null && dt.Rows.Count > 0)
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

            if (dt != null && dt.Rows.Count > 0)
            {
                Session["ReportData"] = dt;

                grdReport.DataSource = dt;
                grdReport.DataBind();
            }

            if (dt.Rows.Count == 0)
            {
                lblMessage.Text = "No Records Found...";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else if (dt.Rows.Count > 0)
            {
                lblMessage.Text = "Total Records: " + dt.Rows.Count.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }

            if (ddlReportType.SelectedValue == "2")
            {
                btnSendMailforPollSubmit.Visible = true;
            }
            else
            {
                btnSendMailforPollSubmit.Visible = false;
            }
        }

        protected void ddlEngineerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSendMailforPollSubmit.Visible = false;
            lblErrorMessage.Text = string.Empty;
            btnSendMailforPollSubmit.Enabled = true;

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

        protected void btnSendMailforPollSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(ddlTriageDates.SelectedValue) < DateTime.Now.Date)
            {
                DataTable dt = new DataTable();
                dt = Session["ReportData"] as DataTable;
                if (dt != null && dt.Rows.Count > 0)
                {
                    string plainContent = "Please submit your poll and help your colleague in improving their skills.";
                    string Subject = "";
                    string HTMLContent = "";

                    foreach (DataRow dr in dt.Rows)
                    {
                        HTMLContent = GetEmailContent(dr[0].ToString(), out Subject);
                        EmailClient.SendMail(dr["Email ID"].ToString(), HttpContext.Current.User.Identity.Name.ToString(), dr[0].ToString(), Subject, HTMLContent, plainContent);
                    }
                }
                
                lblErrorMessage.Text = string.Empty;
                btnSendMailforPollSubmit.Enabled = false;
            }
            else
            {
                lblErrorMessage.Text = "This Triage is not yet delivered...";
            }
        }

        private string GetEmailContent(string toName, out string Subject)
        {
            TriagePollLogic triagepollLogic = new TriagePollLogic();
            string content = "";
            string TriageGivenBy = triagepollLogic.GetTriageOwnerNames(ddlTriageDates.SelectedItem.Text);
            string PollURL = System.Configuration.ConfigurationManager.AppSettings["PollURL"] + ".aspx?TriageDate=" + ddlTriageDates.SelectedItem.Text;
            string TriageDate = ddlTriageDates.SelectedItem.Text;
            string SenderName = triagepollLogic.GetUserName(HttpContext.Current.User.Identity.Name.ToString());
            Subject = string.Format("Triage Manager Updates, Submit your poll for Date: {0}. ", TriageDate);

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"<!DOCTYPE html><html><body style=""font - family:Calibri; font - size:14px""><div>");
                sb.AppendFormat(@"<p>Hello {0},</p><p>You have not yet submitted your <b>POLL</b> for Triage given by: <b>""{1}""</b> delivered on date: <b><a href=""{2}"">""{3}""</a></b>.</p>", toName, TriageGivenBy, PollURL, TriageDate);
                sb.AppendFormat(@"<p>Please submit your poll and help your colleague in improving their skills.</p><br /><p>Thanks,</p><p>{0}</p></div></body></html>", SenderName);
                content = sb.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return content;
        }

    }
}