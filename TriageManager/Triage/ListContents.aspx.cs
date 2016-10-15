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
    public partial class ListContents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TriageContentLogic triageContentLogic = new TriageContentLogic();

            //grdListContents.DataSource = triageContentLogic.GetTriageContents();
            //grdListContents.DataBind();

            if (!IsPostBack)
            {
                TriageContentLogic triageContentLogic = new TriageContentLogic();
                ddlHeading.DataTextField = "TopicName";
                ddlHeading.DataValueField = "SmeTopicsId";
                ddlHeading.DataSource = triageContentLogic.GetSMETopics();
                ddlHeading.DataBind();
            }

        }

        protected void ddlHeading_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriageContentLogic triageContentLogic = new TriageContentLogic();

            DataTable dt = new DataTable();
            DataTable newDT = new DataTable();
            newDT.Columns.Add("FileList");
            newDT.Columns.Add("FilePath");

            //============================================================================================

            dt = triageContentLogic.GetContentsFiles(ddlHeading.SelectedItem.Value, "100");
            
            foreach (DataRow dr in dt.Rows)
            {
                newDT.Rows.Add(dr[0].ToString().Split('_')[1].ToString(), dr[0].ToString());
            }

            grd100.DataSource = newDT;
            grd100.DataBind();

            //============================================================================================

            dt = new DataTable();
            newDT.Rows.Clear();// = new DataTable();

            dt = triageContentLogic.GetContentsFiles(ddlHeading.SelectedItem.Value, "200");

            foreach (DataRow dr in dt.Rows)
            {
                newDT.Rows.Add(dr[0].ToString().Split('_')[1].ToString(), dr[0].ToString());
            }

            grd200.DataSource = newDT;
            grd200.DataBind();

            //============================================================================================

            dt = new DataTable();
            newDT.Rows.Clear();// = new DataTable();

            dt = triageContentLogic.GetContentsFiles(ddlHeading.SelectedItem.Value, "300");

            foreach (DataRow dr in dt.Rows)
            {
                newDT.Rows.Add(dr[0].ToString().Split('_')[1].ToString(), dr[0].ToString());
            }

            grd300.DataSource = newDT;
            grd300.DataBind();

            //============================================================================================

            dt = new DataTable();
            newDT.Rows.Clear();// = new DataTable();

            dt = triageContentLogic.GetContentsFiles(ddlHeading.SelectedItem.Value, "400");

            foreach (DataRow dr in dt.Rows)
            {
                newDT.Rows.Add(dr[0].ToString().Split('_')[1].ToString(), dr[0].ToString());
            }

            grd400.DataSource = newDT;
            grd400.DataBind();
        }
    }
}