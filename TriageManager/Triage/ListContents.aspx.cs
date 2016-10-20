using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.BusinessLogic;
using System.Data;
using System.Configuration;

namespace TriageManager.Triage
{
    public partial class ListContents : System.Web.UI.Page
    {
        string _BlobURL = ConfigurationManager.AppSettings["BlobURL"].ToString();

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

                ddlHeading_SelectedIndexChanged(sender, e);
            }

        }

        protected void ddlHeading_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriageContentLogic triageContentLogic = new TriageContentLogic();

            DataTable dt = new DataTable();
            DataTable newDT = new DataTable();
            newDT.Columns.Add("Row");
            newDT.Columns.Add("FileList");
            newDT.Columns.Add("FilePath");
            newDT.Columns.Add("ContentDescription");

            //============================================================================================

            dt = triageContentLogic.GetContentsFiles(ddlHeading.SelectedItem.Value, "100");
            
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[3].ToString().Equals("Files"))
                    newDT.Rows.Add(dr[0].ToString(), dr[1].ToString().Split('_')[1].ToString(), _BlobURL + dr[1].ToString(), dr[4].ToString());
                else
                    newDT.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[1].ToString(), dr[4].ToString());
            }

            grd100.DataSource = newDT;
            grd100.DataBind();

            //============================================================================================

            dt = new DataTable();
            newDT.Rows.Clear();// = new DataTable();

            dt = triageContentLogic.GetContentsFiles(ddlHeading.SelectedItem.Value, "200");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[3].ToString().Equals("Files"))
                    newDT.Rows.Add(dr[0].ToString(), dr[1].ToString().Split('_')[1].ToString(), _BlobURL + dr[1].ToString(), dr[4].ToString());
                else
                    newDT.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[1].ToString(), dr[4].ToString());
            }

            grd200.DataSource = newDT;
            grd200.DataBind();

            //============================================================================================

            dt = new DataTable();
            newDT.Rows.Clear();// = new DataTable();

            dt = triageContentLogic.GetContentsFiles(ddlHeading.SelectedItem.Value, "300");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[3].ToString().Equals("Files"))
                    newDT.Rows.Add(dr[0].ToString(), dr[1].ToString().Split('_')[1].ToString(), _BlobURL + dr[1].ToString(), dr[4].ToString());
                else
                    newDT.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[1].ToString(), dr[4].ToString());
            }

            grd300.DataSource = newDT;
            grd300.DataBind();

            //============================================================================================

            dt = new DataTable();
            newDT.Rows.Clear();// = new DataTable();

            dt = triageContentLogic.GetContentsFiles(ddlHeading.SelectedItem.Value, "400");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[3].ToString().Equals("Files"))
                    newDT.Rows.Add(dr[0].ToString(), dr[1].ToString().Split('_')[1].ToString(), _BlobURL + dr[1].ToString(), dr[4].ToString());
                else
                    newDT.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[1].ToString(), dr[4].ToString());
            }

            grd400.DataSource = newDT;
            grd400.DataBind();

            //=============================================================================================

            //Here we will show column of update triage level for TA's
            TriagePollLogic triagePollLogic = new TriagePollLogic();

            string Designation = "";
            triagePollLogic.GetReportNameList(HttpContext.Current.User.Identity.Name.ToString(), out Designation);
            Designation = "TA";
            
            if (Designation.Equals("TA") || Designation.Equals("Manager"))
            {
                grd100.Columns[1].Visible = true;
                grd200.Columns[1].Visible = true;
                grd300.Columns[1].Visible = true;
                grd400.Columns[1].Visible = true;
            }
            else
            {
                grd100.Columns[1].Visible = false;
                grd200.Columns[1].Visible = false;
                grd300.Columns[1].Visible = false;
                grd400.Columns[1].Visible = false;
            }
            
        }

        protected void btnTriageLevel100_Click(object sender, EventArgs e)
        {

        }

        protected void btnTriageLevel200_Click(object sender, EventArgs e)
        {

        }

        protected void btnTriageLevel300_Click(object sender, EventArgs e)
        {

        }

        protected void btnTriageLevel400_Click(object sender, EventArgs e)
        {

        }
    }
}