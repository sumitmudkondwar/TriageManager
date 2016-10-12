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
    public partial class ContentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TriageContentLogic triageContentLogic = new TriageContentLogic();
            string GUID = Request["GUID"].ToString();
            lblTopic.Text = Request["ContentHeading"].ToString();

            DataTable ContentDT = new DataTable();
            ContentDT = triageContentLogic.GetTriageContentsGUID(GUID);

            lblContributor.Text = ContentDT.Rows[0][4].ToString();
            txtDescription.Text = ContentDT.Rows[0][2].ToString();

            DataTable dt = triageContentLogic.GetTriageContentsFiles(GUID);
            DataTable newDT = new DataTable();
            newDT.Columns.Add("FileList");
            newDT.Columns.Add("FilePath");

            foreach (DataRow dr in dt.Rows)
            {
                newDT.Rows.Add(dr[0].ToString().Split('_')[1].ToString(), dr[0].ToString());
            }

            grdListFiles.DataSource = newDT;
            grdListFiles.DataBind();
        }
    }
}