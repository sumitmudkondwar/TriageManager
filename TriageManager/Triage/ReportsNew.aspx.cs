using DataAccessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TriageManager.Triage
{
    public partial class ReportsNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                TriagePollLogic triagePollLogic = new TriagePollLogic();
                string Designation = "";
                Designation = triagePollLogic.GetDesignation("sumudk@microsoft.com");

                if (Designation.Equals("Support Engineer"))
                {
                    dt = new DataTable();
                    dvSETriageReport.Visible = true;
                    dvAccordian.Visible = false;

                    dt = triagePollLogic.GetReportDataForAll(HttpContext.Current.User.Identity.Name.ToString());
                    grdSETriageReport.DataSource = dt;
                    grdSETriageReport.DataBind();
                    if (dt.Rows.Count == 0)
                    {
                        lblMessage.Text = "No Records Found...";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblMessage.Text = "Total Submitted Polls: " + dt.Rows.Count.ToString();
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else if (Designation.Equals("Manager") || Designation.Equals("TA"))
                {
                    dvSETriageReport.Visible = false;
                    dvAccordian.Visible = true;

                    dt = triagePollLogic.GetTriageCalender();

                    rptAccordian.DataSource = dt;
                    rptAccordian.DataBind();
                }
                else
                {
                    dvAccordian.Visible = false;
                    dvSETriageReport.Visible = true;
                    grdSETriageReport.Visible = false;
                    lblMessage.Text = "You are not a Member of Triage Series yet!!!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void rptAccordian_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            dynamic rowData = e.Item.DataItem;
            string TriageDate = rowData.Row.ItemArray[0].ToString();
            string Designation = string.Empty;

            GridView grdPollData = new GridView();
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            DataTable dt = new DataTable();

            

            if(Designation.Equals("Manager") || Designation.Equals("TA"))
                dt = triagePollLogic.GetReportData(TriageDate, "1", Designation);
            else if(Designation.Equals("Support Engineer"))
                dt = triagePollLogic.GetReportData(TriageDate, "2", Designation);


            grdPollData = e.Item.FindControl("grdPollData") as GridView;
            grdPollData.DataSource = dt;
            grdPollData.DataBind();
        }

        //protected void rptAccordian_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //DataTable dt = new DataTable();
        //TriagePollLogic triagePollLogic = new TriagePollLogic();

        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    dynamic person = e.Item.DataItem as dynamic;

        //    string name = person.Row.ItemArray[1];
        //    dt = triagePollLogic.GetTriageDateList(name);

        //    Repeater ctrlDateRepeater = new Repeater();
        //    ctrlDateRepeater = e.Item.FindControl("rptDateAccordian") as Repeater;
        //    ctrlDateRepeater.DataSource = dt;
        //    ctrlDateRepeater.DataBind();
        //}

        //}
    }
}