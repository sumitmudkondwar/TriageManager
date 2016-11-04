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
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = null;
            DataSet ds1 = null;
            DataSet ds2 = null;
            DataSet ds3 = null;
            DataSet ds4 = null;
            DataSet ds5 = null;
            SqlDataAdapter sqldda = null;

            System.Data.SqlClient.SqlConnection sqlConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();


            cmd.CommandText = "SELECT designation from Users where emailID = '" +
                HttpContext.Current.User.Identity.Name.ToString() + "'";
            ds3 = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds3);

            //if (ds3.Tables[0].Rows.Count == 0 || ds3.Tables[0].Rows[0][0].ToString() == "Support Engineer")
            //{
            //    sqlConnection.Close();
            //    pnlReport.Visible = false;
            //    lblComment.Text = "Only TA/Manager can assess Reports of the engineers";
            //    return;
            //}

            pnlReport.Visible = true;


            cmd.CommandText = "SELECT [firstname] Name,[Availability / Performance],[VNET / Hybrid],[ASE],[Mobile Apps]," +
                "[WebJobs / Functions],[Azure App Service on Linux],[Deployment],[Easy Authentication],[AutoScale / Alerts],[Swap / Slots]," +
                "[BYOD / App Service Certificate],[Powershell / ARM APIs],[OSS]" +
                ",convert(varchar, TRY_PARSE([EngineerAssessmentDate] as date)) EngDate FROM[dbo].[Assessment], [Users] where [EngineerAssessment] = 'Yes'  and [Assessment].Engineer = [Users].emailID  order by Name";
            ds4 = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds4);

            grdEngAssess.DataSource = ds4;
            grdEngAssess.DataBind();

            cmd.CommandText = "SELECT [firstname] Name,[Availability / Performance],[VNET / Hybrid],[ASE],[Mobile Apps]," +
                "[WebJobs / Functions],[Azure App Service on Linux],[Deployment],[Easy Authentication],[AutoScale / Alerts],[Swap / Slots]," +
                "[BYOD / App Service Certificate],[Powershell / ARM APIs],[OSS],[Other Configuration],[Stress Testing]" +
                ",[TAAssessmentBy] TA,convert(varchar, TRY_PARSE([TAAssessmentDate] as date)) TADate FROM[dbo].[Assessment], [Users] where [TAAssessment] = 'Yes'  and [Assessment].Engineer = [Users].emailID  order by Name";
            ds5 = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds5);

            grdTAAssess.DataSource = ds5;
            grdTAAssess.DataBind();

            cmd.CommandText = "SELECT emailID, firstName name from Users where [Designation] = 'Support Engineer'";
            ds = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds);

            cmd.CommandText = "SELECT topic from Tasks";
            ds1 = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds1);

            cmd.CommandText = "select task, engineer, engineerstatus, tastatus from TDPtasks";
            ds2 = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds2);

            sqlConnection.Close();

            DataTable dt = new DataTable();
            dt.Columns.Add("Engineer");
            dt.Columns.Add("Name");

            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                dt.Columns.Add(row[0].ToString());
            }

            foreach (DataRow row in ds.Tables[0].Rows)
            {                
                dt.Rows.Add();
                int count = dt.Rows.Count;
                dt.Rows[count - 1][0] = row[0].ToString();
                dt.Rows[count - 1][1] = row[1].ToString();
            }

            dt.DefaultView.Sort = "Name asc";
            DataTable dt1 = dt.Copy();

            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                string select = "Engineer ='" + row[1].ToString() + "'";
                DataRow[] result = dt.Select(select.ToString());
                
                    int SelectedIndex = dt.Rows.IndexOf(result[0]);
                dt.Rows[SelectedIndex][row[0].ToString()] = row[3].ToString();
                
            }

            dt.Columns.Remove("Engineer");
                        
            grdTA.DataSource = dt;
            grdTA.DataBind();

            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                string select1 = "Engineer ='" + row[1].ToString() + "'";
                DataRow[] result = dt1.Select(select1.ToString());

                int SelectedIndex = dt1.Rows.IndexOf(result[0]);
                dt1.Rows[SelectedIndex][row[0].ToString()] = row[2].ToString();

            }

            dt1.Columns.Remove("Engineer");
            
            dt1.DefaultView.Sort = "Name asc";
            grdEngineer.DataSource = dt1;
            grdEngineer.DataBind();
        }
    }
}