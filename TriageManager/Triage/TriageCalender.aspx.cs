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
            if (!IsPostBack)
            {
                GridDataBind();
            }
        }

        private void GridDataBind()
        {
            DataTable dt = new DataTable();

            TriagePollLogic triagePollLogic = new TriagePollLogic();
            dt = triagePollLogic.GetTriageCalender();
            grdTriageCalender.DataSource = dt;
            grdTriageCalender.DataBind();

            dt = new DataTable();
            dt = triagePollLogic.GetReportTriageAttended("sumudk@microsoft.com");

            foreach (GridViewRow row in grdTriageCalender.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Button btnMyPoll = row.FindControl("btnMyPoll") as Button;
                    if (row.Cells[5].Text.Equals("Not Completed"))
                    {
                        btnMyPoll.Visible = false;
                    }
                    else if (row.Cells[5].Text.Equals("Completed"))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (Convert.ToDateTime(dr["Date"].ToString()) == Convert.ToDateTime(row.Cells[0].Text))
                            {
                                btnMyPoll.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        protected void btnMyPoll_Click(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)((Button)sender).NamingContainer;
            Response.Redirect("~/Triage/MyPoll.aspx?TriageDate=" + gridViewRow.Cells[0].Text);
        }
    }
}