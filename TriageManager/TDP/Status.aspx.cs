using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TriageManager.TDP
{
    public partial class Status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }

        protected void grdTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlStatus.Visible = true;
            GridViewRow row = grdTasks.SelectedRow;
            hidID.Value = row.Cells[1].Text.ToString();
            lblTaskName.Text = row.Cells[2].Text.ToString();
            lblDetailInfo.Text = row.Cells[9].Text.ToString();
            ddlStatus.SelectedValue = row.Cells[6].Text.ToString();
            txtComment.Text = row.Cells[8].Text.Replace("<br>", "\n").ToString();
            txtUpdate.Text = string.Empty;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection sqlConnection =
                new System.Data.SqlClient.SqlConnection("server=triageserver.database.windows.net;database=TriageDB;uid=triage;password=sme@12345;");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            string update = txtComment.Text.Replace("\n", "<br>").ToString() + Environment.NewLine + DateTime.Now.ToString() + 
                " Engineer " + HttpContext.Current.User.Identity.Name.ToString() + " Updated Status as " +
                ddlStatus.SelectedItem.Text.ToString() + " " + Environment.NewLine + txtUpdate.Text.Replace("\n", "<br>").ToString() + Environment.NewLine;

            cmd.CommandText = "UPDATE [dbo].[TDPtasks] SET [EngineerStatus] = '" +
            ddlStatus.SelectedItem.Text.ToString() + "' , [Comments] = '" +
            update.ToString() + "' WHERE TaskID = " + hidID.Value.ToString();
            cmd.ExecuteNonQuery();

            sqlConnection.Close();

            lblComment.Text = "Status Updated. Check the table above for confirmation. ";
            bindGrid();

            pnlStatus.Visible = false;
        }

        protected void grdTasks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string decodedText1 = HttpUtility.HtmlDecode(e.Row.Cells[8].Text);
            e.Row.Cells[8].Text = decodedText1;
            string decodedText2 = HttpUtility.HtmlDecode(e.Row.Cells[9].Text);
            e.Row.Cells[9].Text = decodedText2;
        }

        protected void bindGrid()
        {
            try
            { 
            string email = HttpContext.Current.User.Identity.Name.ToString();            

            DataSet ds = null;
            SqlDataAdapter sqldda = null;

            System.Data.SqlClient.SqlConnection sqlConnection =
                new System.Data.SqlClient.SqlConnection("server=triageserver.database.windows.net;database=TriageDB;uid=triage;password=sme@12345;");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            cmd.CommandText = "SELECT TDPtasks.taskid, TDPtasks.task Topic, Priority, etcompletion ETA, assigneddate Assigned, engineerstatus Status, tastatus TA, Comments, tasks.task Task from TDPTasks, Tasks where TDPtasks.Task = Tasks.Topic and Engineer = '" + email.ToString() + "' order by Priority";
            ds = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds);

            sqlConnection.Close();

            if (ds.Tables[0].Rows.Count == 0)
                {
                    lblComment.Text = "No Tasks assigned";
                    pnlGrid.Visible = false;
                }
            else
                { 
            grdTasks.DataSource = ds.Tables[0];                
            grdTasks.DataBind();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}