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
            dt = triagePollLogic.GetTriageCalender();

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
            dynamic rowData = e.Item.DataItem;
            string TriageDate = rowData.Row.ItemArray[0].ToString();
            TriagePollLogic triagePollLogic = new TriagePollLogic();
            DataTable dt = new DataTable();
            dt = triagePollLogic.GetReportData(TriageDate, "1", "Manager");

            GridView grdAcc = new GridView();
            grdAcc = e.Item.FindControl("grdPollData") as GridView;

            grdAcc.DataSource = dt;
            grdAcc.DataBind();
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