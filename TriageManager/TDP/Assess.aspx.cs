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
    public partial class Assess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = null;
                SqlDataAdapter sqldda = null;

                System.Data.SqlClient.SqlConnection sqlConnection =
                    new System.Data.SqlClient.SqlConnection("server=triageserver.database.windows.net;database=TriageDB;uid=triage;password=sme@12345;");

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                cmd.CommandText = "SELECT designation from Users where emailID = '" +
                    HttpContext.Current.User.Identity.Name.ToString() + "'";
                ds = new DataSet();
                sqldda = new SqlDataAdapter(cmd);
                sqldda.Fill(ds);

                sqlConnection.Close();

                if (ds.Tables[0].Rows.Count == 0 || ds.Tables[0].Rows[0][0].ToString() == "Support Engineer")
                {
                    ddlEngineer.Visible = false;
                    lblEngineer.Visible = false;
                    lblComment.Text = "Only TA/Manager can assess Tasks of the engineers";
                    return;
                }

                ds = new DataSet();
                sqldda = new SqlDataAdapter(cmd);

                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                cmd.CommandText = "SELECT CONCAT(firstName, ' ', lastname) name, emailID from Users where designation = 'Support Engineer'";
                ds = new DataSet();
                sqldda = new SqlDataAdapter(cmd);
                sqldda.Fill(ds);

                ddlEngineer.DataSource = ds.Tables[0];
                ddlEngineer.DataTextField = "name";
                ddlEngineer.DataValueField = "emailID";
                ddlEngineer.DataBind();
                ddlEngineer.Items.Insert(0, "Select");

                sqlConnection.Close();
            }
        }

        protected void ddlEngineer_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGrid();
        }

        protected void grdTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDetails.Visible = true;
            GridViewRow row = grdTasks.SelectedRow;
            hidID.Value = row.Cells[1].Text.ToString();
            lblTaskName.Text = row.Cells[2].Text.ToString();
            lblDetailInfo.Text = row.Cells[9].Text.ToString();
            ddlStatus.SelectedValue = row.Cells[7].Text.ToString();
            txtComment.Text = row.Cells[8].Text.Replace("<br>", "\n").ToString();
            txtUpdate.Text = string.Empty;

            if (row.Cells[7].Text.ToString() == "Completed")
            {
                lblComment.Text = "Task is completed.";
                btnUpdate.Visible = false;
            }
            else
            {
                lblComment.Text = string.Empty;
                btnUpdate.Visible = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string email = HttpContext.Current.User.Identity.Name.ToString();
            
            System.Data.SqlClient.SqlConnection sqlConnection =
                new System.Data.SqlClient.SqlConnection("server=triageserver.database.windows.net;database=TriageDB;uid=triage;password=sme@12345;");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            string update = txtComment.Text.Replace("\n", "<br>").ToString() + Environment.NewLine + DateTime.Now.ToString() + " TA " +
                email.ToString() + " Updated Status as " + ddlStatus.SelectedItem.Text.ToString() + " " + Environment.NewLine + 
                txtUpdate.Text.Replace("\n", "<br>").ToString() + Environment.NewLine;

            cmd.CommandText = "UPDATE [dbo].[TDPtasks] SET [TAStatus] = '" +
            ddlStatus.SelectedItem.Text.ToString() + "' , [Comments] = '" +
            update.ToString() + "' WHERE TaskID = " + hidID.Value.ToString();
            cmd.ExecuteNonQuery();

            cmd.CommandText = "UPDATE [dbo].[Assessment] SET [" +
                lblTaskName.Text.ToString() + "] = " + Convert.ToInt32(rdlLevel.SelectedValue.ToString()) +
                ",[FinalAssessmentBy] = '" + email.ToString() +
                "',[FinalAssessmentDate] = '" + DateTime.Now.ToString() +
                "' where [Engineer] = '" + ddlEngineer.SelectedValue.ToString() +
                "' and [FinalAssessment] = 'Yes'";

            cmd.ExecuteNonQuery();

            sqlConnection.Close();

            lblComment.Text = "Status Updated. Check the table above for confirmation. ";
            bindGrid();

            pnlDetails.Visible = false;
        }


        protected void bindGrid()
        {
            string email = ddlEngineer.SelectedValue.ToString();

            DataSet ds = null;
            SqlDataAdapter sqldda = null;

            System.Data.SqlClient.SqlConnection sqlConnection =
                new System.Data.SqlClient.SqlConnection("server=triageserver.database.windows.net;database=TriageDB;uid=triage;password=sme@12345;");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            cmd.CommandText = "SELECT TDPtasks.taskid, TDPtasks.task Topic, Priority, etcompletion ETA, assigneddate Assigned, engineerstatus Status, tastatus TA, Comments, tasks.task Task from TDPTasks, Tasks where TDPtasks.Task = Tasks.Topic and Engineer = '" + email.ToString() + "' order by priority";
            ds = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
            {
                lblComment.Text = "No Tasks assigned for this engineer";
                pnlDetails.Visible = false;
                grdTasks.Visible = false;
            }
            else
            {
                grdTasks.Visible = true;
                grdTasks.DataSource = ds.Tables[0];
                grdTasks.DataBind();
                lblComment.Text = string.Empty;
            }

            sqlConnection.Close();
        }

        protected void grdTasks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string decodedText1 = HttpUtility.HtmlDecode(e.Row.Cells[8].Text);
            e.Row.Cells[8].Text = decodedText1;
            string decodedText2 = HttpUtility.HtmlDecode(e.Row.Cells[9].Text);
            e.Row.Cells[9].Text = decodedText2;
        }
    }
}