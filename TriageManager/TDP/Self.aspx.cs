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
    public partial class Self : System.Web.UI.Page
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

                cmd.CommandText = "SELECT * from Assessment where engineer = '" +
                    HttpContext.Current.User.Identity.Name.ToString() + "'";
                ds = new DataSet();
                sqldda = new SqlDataAdapter(cmd);
                sqldda.Fill(ds);

                sqlConnection.Close();

                if (ds.Tables[0].Rows.Count == 0)
                {
                    pnlAssess.Visible = true;
                    lblComment.Visible = false;
                }
                else
                {
                    pnlAssess.Visible = false;
                    lblComment.Visible = true;
                    lblComment.Text = "Self Assessment is already completed";
                }
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string email = HttpContext.Current.User.Identity.Name.ToString();

                System.Data.SqlClient.SqlConnection sqlConnection =
                    new System.Data.SqlClient.SqlConnection("server=triageserver.database.windows.net;database=TriageDB;uid=triage;password=sme@12345;");

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                cmd.CommandText = "INSERT INTO [dbo].[Assessment] ([Engineer], [Availability / Performance],[VNET / Hybrid] " +
                    ",[ASE],[Mobile Apps],[WebJobs / Functions],[Azure App Service on Linux],[Deployment],[Easy Authentication] " +
                    ",[AutoScale / Alerts],[Swap / Slots],[BYOD / App Service Certificate],[Powershell / ARM APIs],[OSS]" + 
                    ",[EngineerAssessment],[EngineerAssessmentDate]) VALUES ('" +
                    email.ToString() + "'," +
                    Convert.ToInt32(RadioButtonList1.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList2.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList3.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList4.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList5.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList6.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList7.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList8.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList9.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList10.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList11.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList12.SelectedValue.ToString()) + "," +
                    Convert.ToInt32(RadioButtonList13.SelectedValue.ToString()) + "," +
                    "'Yes','" + DateTime.Now.ToString() +
                    "')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO [dbo].[Assessment] ([Engineer], [TAAssessment]) VALUES ('" +
                    email.ToString() + "','Yes')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO [dbo].[Assessment] ([Engineer], [FinalAssessment]) VALUES ('" +
                    email.ToString() + "','Yes')";
                cmd.ExecuteNonQuery();

                sqlConnection.Close();

                pnlAssess.Visible = false;
                lblComment.Visible = true;
                lblComment.Text = "Self Assessment is completed.";


            }
            catch (Exception Ex)
            {
                pnlAssess.Visible = true;
                lblComment.Visible = true;
                lblComment.Text = "Self Assessment failed";
            }
        }
    }
}