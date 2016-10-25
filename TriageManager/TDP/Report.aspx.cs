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
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = null;
            DataSet ds1 = null;
            DataSet ds2 = null;
            SqlDataAdapter sqldda = null;

            System.Data.SqlClient.SqlConnection sqlConnection =
                new System.Data.SqlClient.SqlConnection("server=triageserver.database.windows.net;database=TriageDB;uid=triage;password=sme@12345;");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            cmd.CommandText = "SELECT emailID, firstName name from Users";
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
            dt.Columns.Add("Name ");

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

            grdEngineer.DataSource = dt1;
            grdEngineer.DataBind();
        }
    }
}