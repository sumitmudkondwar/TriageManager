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

            rptAccordian.DataSource = dt;
            rptAccordian.DataBind();


            
            //string html = "";
            //foreach (DataRow dr in dt.Rows)
            //{
            //    html = html + "<h3>" + dr[0].ToString() + "</h3><div><p></p></div>";
            //}

            //HtmlGenericControl div = new HtmlGenericControl("accordion");
            //div.InnerHtml = html;

            //ContentPlaceHolder cph;
            //Literal lit;

            //cph = (ContentPlaceHolder)Master.FindControl("MainContent");

            //if (cph != null)
            //{
            //    lit = (Literal)cph.FindControl("accordion");
            //    if (lit != null)
            //    {
            //        lit.Text = "Some <b>HTML</b>";
            //    }
            //}


            //accordion.InnerHtml = html;
        }

        protected void rptAccordian_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
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

        }
    }
}