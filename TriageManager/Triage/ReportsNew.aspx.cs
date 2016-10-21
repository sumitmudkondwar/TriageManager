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
            DataTable dt = new DataTable();
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            string Designation = "";
            dt = triagePollLogic.GetReportNameList("sumudk@microsoft.com", out Designation);
            string html = "";


            foreach (DataRow dr in dt.Rows)
            {
                html = html + "<h3>" + dr[0].ToString() + "</h3><div><p></p></div>";
            }

            //HtmlGenericControl div = new HtmlGenericControl("accordion");
            //div.InnerHtml = html;

            ContentPlaceHolder cph;
            Literal lit;

            cph = (ContentPlaceHolder)Master.FindControl("MainContent");

            if (cph != null)
            {
                lit = (Literal)cph.FindControl("accordion");
                if (lit != null)
                {
                    lit.Text = "Some <b>HTML</b>";
                }
            }


            //accordion.InnerHtml = html;
        }
    }
}