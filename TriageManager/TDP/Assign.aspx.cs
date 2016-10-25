using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TriageManager.TDP
{
    public partial class Assign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = null;
                SqlDataAdapter sqldda = null;

                System.Data.SqlClient.SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

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
                    pnlAdd.Visible = false;
                    lblComment.Text = "Only TA/Manager can assign Tasks";
                    return;
                }

                ds = new DataSet();
                sqldda = new SqlDataAdapter(cmd);

                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                cmd.CommandText = "SELECT CONCAT(firstName, ' ', lastname) name, emailID from Users where designation = 'Support Engineer' order by name";
                ds = new DataSet();
                sqldda = new SqlDataAdapter(cmd);
                sqldda.Fill(ds);

                ddlEngineer.DataSource = ds.Tables[0];
                ddlEngineer.DataTextField = "name";
                ddlEngineer.DataValueField = "emailID";
                ddlEngineer.DataBind();
                ddlEngineer.Items.Insert(0, "Select");


                cmd.CommandText = "SELECT Topic from Tasks order by Topic";
                ds = new DataSet();
                sqldda = new SqlDataAdapter(cmd);
                sqldda.Fill(ds);

                ddlTopic.DataSource = ds.Tables[0];
                ddlTopic.DataTextField = "Topic";
                ddlTopic.DataValueField = "Topic";
                ddlTopic.DataBind();
                ddlTopic.Items.Insert(0, "Select");

                for (int i = 1; i <= 20; i++)
                {
                    ddlPriority.Items.Add(i.ToString());
                }

                sqlConnection.Close();                
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEngineer.SelectedIndex == 0 || ddlTopic.SelectedIndex == 0 || calETA.SelectedDate.ToString() == "01-01-0001 00:00:00")
                {
                    lblComment.Text = "Select appropriate values for Engineer / Topic / ET Completion";
                    return;
                }

                string email = HttpContext.Current.User.Identity.Name.ToString();
                
                System.Data.SqlClient.SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                string assesment = DateTime.Now.ToString() + " Initial Assessment done by " + email.ToString() + Environment.NewLine + 
                    txtAssessment.Text.ToString() + Environment.NewLine;


                cmd.CommandText = "UPDATE [dbo].[Assessment] SET [" +
                    ddlTopic.SelectedItem.Text.ToString() + "] = " + Convert.ToInt32(rdlLevel.SelectedValue.ToString()) +
                    ",[TAAssessmentBy] = '" + email.ToString() +
                    "',[TAAssessmentDate] = '" + DateTime.Now.ToString() +
                    "' where [Engineer] = '" + ddlEngineer.SelectedValue.ToString() +
                    "' and [TAAssessment] = 'Yes'";

                cmd.ExecuteNonQuery();


                cmd.CommandText = "INSERT INTO [dbo].[TDPtasks] ([Engineer] ,[Task] ,[Priority] ,[ETCompletion] ,[AssignedBy] ,[AssignedDate] ,[EngineerStatus] ,[TAStatus] ,[TALastUpdate] ,[Comments]) VALUES ('" +
                    ddlEngineer.SelectedValue.ToString() + "','" +
                    ddlTopic.SelectedItem.Text.ToString() + "','" +
                    Convert.ToInt32(ddlPriority.SelectedItem.Text.ToString()) + "','" +
                    calETA.SelectedDate.ToString() + "','" +
                    email.ToString() + "','" +
                    DateTime.Now.ToString() + "','" +
                    "Assigned','Assigned" + "','" +
                    DateTime.Now.ToString() + "','" +
                    assesment.Replace("\n", "<br>").ToString() + 
                    "')";
                cmd.ExecuteNonQuery();

                sqlConnection.Close();
                
                lblComment.Text = "Topic '" + ddlTopic.SelectedItem.Text.ToString() + "' assigned to " + ddlEngineer.SelectedItem.ToString() + ".";
                ddlTopic.SelectedIndex = 0;
                txtAssessment.Text = string.Empty;
                ddlPriority.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                lblComment.Text = "Engineer Self Asssessment not yet completed";
            }
        }

        protected void calETA_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.CompareTo(DateTime.Today) < 0)
            {
                e.Day.IsSelectable = false;
            }
        }
    }
}