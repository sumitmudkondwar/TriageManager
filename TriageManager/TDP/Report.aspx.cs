using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            try
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

                if (ds3.Tables[0].Rows.Count == 0 || ds3.Tables[0].Rows[0][0].ToString() == "Support Engineer")
                {
                    sqlConnection.Close();
                    pnlReport.Visible = false;
                    lblComment.Text = "Only TA/Manager can assess Reports of the engineers";
                    return;
                }

                pnlReport.Visible = true;


            cmd.CommandText = "SELECT left([firstname],10) EngineerName,[Availability / Performance],[VNET / Hybrid],[ASE],[Mobile Apps]," +
                "[WebJobs / Functions],[Azure App Service on Linux],[Deployment],[Easy Authentication],[AutoScale / Alerts],[Swap / Slots]," +
                "[BYOD / App Service Certificate],[Powershell / ARM APIs],[OSS]" +
                ",convert(varchar, TRY_PARSE([EngineerAssessmentDate] as date)) LastUpdate FROM[dbo].[Assessment], [Users] where [EngineerAssessment] = 'Yes'  and [Assessment].Engineer = [Users].emailID  order by EngineerName";
            ds4 = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds4);
                
                (ds4.Tables[0]).SetColumnsOrder("EngineerName", "Availability / Performance", "Deployment", "VNET / Hybrid", "ASE", "WebJobs / Functions", 
                    "Swap / Slots", "Mobile Apps", "Easy Authentication", "AutoScale / Alerts", "BYOD / App Service Certificate", 
                    "Powershell / ARM APIs", "Azure App Service on Linux", "OSS", "LastUpdate");

                DataTable dtCloned = ds4.Tables[0].Clone();
                foreach (DataColumn col in dtCloned.Columns)
                    col.DataType = typeof(string); 

                foreach (DataRow row in ds4.Tables[0].Rows)
                {
                    dtCloned.ImportRow(row);
                }

                grdEngAssess.DataSource = ds4;
            grdEngAssess.DataBind();


                cmd.CommandText = "select rep.*, left([Users].[firstName],10) AssessedBy from (SELECT left([firstname],10) EngineerName,[Availability / Performance],[VNET / Hybrid],[ASE],[Mobile Apps]," +
                "[WebJobs / Functions],[Azure App Service on Linux],[Deployment],[Easy Authentication],[AutoScale / Alerts],[Swap / Slots]," +
                "[BYOD / App Service Certificate],[Powershell / ARM APIs],[OSS],[Other Configuration],[Stress Testing]" +
                ",[TAAssessmentBy],convert(varchar, TRY_PARSE([TAAssessmentDate] as date)) LastUpdate FROM[dbo].[Assessment], [Users] where [TAAssessment] = 'Yes'  and [Assessment].Engineer = [Users].emailID) rep, [Users] " +
                "where rep.[TAAssessmentBy] = [Users].emailID order by EngineerName";
            ds5 = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds5);
            ds5.Tables[0].Columns.RemoveAt(16);


                ds5.Tables[0].DefaultView.Sort = "EngineerName asc";

                (ds5.Tables[0]).SetColumnsOrder("EngineerName", "Availability / Performance", "Deployment", "VNET / Hybrid", "ASE", "WebJobs / Functions",
                    "Swap / Slots", "Mobile Apps", "Easy Authentication", "AutoScale / Alerts", "BYOD / App Service Certificate",
                    "Powershell / ARM APIs", "Other Configuration", "Stress Testing", "Azure App Service on Linux", "OSS", "AssessedBy", "LastUpdate");

                grdTAAssess.DataSource = ds5;
            grdTAAssess.DataBind();

            cmd.CommandText = "SELECT emailID, left(firstName,10) EngineerName from Users where [Designation] = 'Support Engineer'";
            ds = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds);

            cmd.CommandText = "SELECT topic from Tasks";
            ds1 = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds1);

            cmd.CommandText = "select task, engineer, concat(left(isnull(engineerstatus,'NULL'),4), ' | ', left(isnull(tastatus,'NULL'),4)), convert(varchar, TRY_PARSE([ETCompletion] as date)) ETA from TDPtasks";
            ds2 = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds2);

            sqlConnection.Close();

            DataTable dt = new DataTable();
            dt.Columns.Add("Engineer");
            dt.Columns.Add("EngineerName");

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
                DataTable eta = dt.Copy();
                dt.DefaultView.Sort = "EngineerName asc";
                dt1.DefaultView.Sort = "EngineerName asc";
                eta.DefaultView.Sort = "EngineerName asc";

                foreach (DataRow row in ds2.Tables[0].Rows)
            {
                string select = "Engineer ='" + row[1].ToString() + "'";
                DataRow[] result = dt.Select(select.ToString());

                    int SelectedIndex = dt.Rows.IndexOf(result[0]);
                dt.Rows[SelectedIndex][row[0].ToString()] = row[2].ToString();
                    dt1.Rows[SelectedIndex][row[0].ToString()] = row[2].ToString();
                    eta.Rows[SelectedIndex][row[0].ToString()] = row[3].ToString();

                }

            dt.Columns.Remove("Engineer");

                dt.SetColumnsOrder("EngineerName", "Availability / Performance", "Deployment", "VNET / Hybrid", "ASE", "WebJobs / Functions",
                    "Swap / Slots", "Mobile Apps", "Easy Authentication", "AutoScale / Alerts", "BYOD / App Service Certificate",
                    "Powershell / ARM APIs", "Other Configuration", "Stress Testing", "Azure App Service on Linux", "OSS");

            //    grdTA.DataSource = dt;
            //grdTA.DataBind();

            //foreach (DataRow row in ds2.Tables[0].Rows)
            //{
            //    string select1 = "Engineer ='" + row[1].ToString() + "'";
            //    DataRow[] result1 = dt1.Select(select1.ToString());

            //    int SelectedIndex = dt1.Rows.IndexOf(result[0]);
            //    dt1.Rows[SelectedIndex][row[0].ToString()] = row[2].ToString();

            //}

            dt1.Columns.Remove("Engineer");

                dt1.SetColumnsOrder("EngineerName", "Availability / Performance", "Deployment", "VNET / Hybrid", "ASE", "WebJobs / Functions",
                    "Swap / Slots", "Mobile Apps", "Easy Authentication", "AutoScale / Alerts", "BYOD / App Service Certificate",
                    "Powershell / ARM APIs", "Other Configuration", "Stress Testing", "Azure App Service on Linux", "OSS");

                grdEngineer.DataSource = dt1;
            grdEngineer.DataBind();


                DataTable dt2 = dt1.Copy();
                DataTable dt3 = dtCloned.Copy();
                foreach(DataRow row in dt2.Rows)
                {
                    dt3.ImportRow(row);
                }
                foreach (DataRow row1 in eta.Rows)
                {
                    dt3.ImportRow(row1);
                }

                dt3.Columns.Remove("LastUpdate");
                dt3.DefaultView.Sort = "EngineerName asc";

                //grdConsolidate.DataSource = dt3;
                //grdConsolidate.DataBind();

            }
            catch(Exception ex)
            {

            }
       }

        protected void grdEngineer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    //TableCell cell = e.Row.Cells[1];
                    string text = cell.Text.ToString();

                    if (text.Contains("Comp | Comp"))
                    {
                        cell.BackColor = Color.LawnGreen;
                    }
                    else if (text.Contains("Comp |"))
                    {
                        cell.BackColor = Color.LightGreen;
                    }
                    else if (text.Contains("InPr |"))
                    {
                        cell.BackColor = Color.Cyan;
                    }
                }
            }
        }

        protected void grdConsolidate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try { 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    //TableCell cell = e.Row.Cells[1];
                    string text = cell.Text.ToString();

                    if (text.Contains("Comp | Comp"))
                    {
                        cell.BackColor = Color.LawnGreen;
                    }
                    else if (text.Contains("Comp |"))
                    {
                        cell.BackColor = Color.LightGreen;
                    }
                    else if (text.Contains("InPr |"))
                    {
                        cell.BackColor = Color.Cyan;
                        }
                        //else if (text.StartsWith("2016") || text.StartsWith("2017"))
                        //{
                        //    string a = Convert.ToDateTime(text).ToString();
                        //    if (DateTime.Now > Convert.ToDateTime(text))
                        //    {
                        //        cell.BackColor = Color.Red;
                        //    }
                        //    else if (DateTime.Now.AddDays(7) > Convert.ToDateTime(text))
                        //    {
                        //        cell.BackColor = Color.Orange;
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CombineColumnCells(GridViewRow currentRow, int colIndex, string fieldName)
        {
            try
            {
                TableCell currentCell = currentRow.Cells[colIndex];

                if (currentCell.Visible)
                {
                    Object currentValue = grdConsolidate.DataKeys[currentRow.RowIndex].Values[fieldName];

                    for (int nextRowIndex = currentRow.RowIndex + 1; nextRowIndex < grdConsolidate.Rows.Count; nextRowIndex++)
                    {
                        Object nextValue = grdConsolidate.DataKeys[nextRowIndex].Values[fieldName];

                        if (nextValue.ToString() == currentValue.ToString())
                        {
                            GridViewRow nextRow = grdConsolidate.Rows[nextRowIndex];
                            TableCell nextCell = nextRow.Cells[colIndex];
                            currentCell.RowSpan = Math.Max(1, currentCell.RowSpan) + 1;
                            nextCell.Visible = false;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void grdConsolidate_DataBound(object sender, EventArgs e)
        {
            try
            {
                for (int currentRowIndex = 0; currentRowIndex < grdConsolidate.Rows.Count; currentRowIndex++)
                {
                    GridViewRow currentRow = grdConsolidate.Rows[currentRowIndex];
                    CombineColumnCells(currentRow, 0, "EngineerName");

                    int cellCount = currentRow.Cells.Count;
                    int i = 0;

                    foreach(TableCell cell in currentRow.Cells)
                    {
                        if (i == cellCount)
                            i = 0;
                        if ((cell.Text.StartsWith("2016") || cell.Text.StartsWith("2017")) && (!grdConsolidate.Rows[currentRowIndex - 1].Cells[i].Text.Contains("Comp")))
                        {
                            if (DateTime.Now > Convert.ToDateTime(cell.Text))
                            {
                                cell.BackColor = Color.Red;
                            }
                            else if (DateTime.Now.AddDays(7) > Convert.ToDateTime(cell.Text))
                            {
                                cell.BackColor = Color.Orange;
                            }
                        }
                        else if ((cell.Text.StartsWith("2016") || cell.Text.StartsWith("2017")))
                        {

                        }

                        i = i + 1;
                    }
                }

                //foreach (DataGridColumn col in grdConsolidate.Columns)
                //{
                //    this.grdConsolidate.Columns.si
                //    col.s
                //    DataGridViewColumn.AutoSizeMode
                //}
            }
            catch (Exception ex)
            {

            }
        }
    }



    public static class DataTableExtensions
    {
        public static void SetColumnsOrder(this DataTable table, params String[] columnNames)
        {
            try
            {
                int columnIndex = 0;
                foreach (var columnName in columnNames)
                {
                    table.Columns[columnName].SetOrdinal(columnIndex);
                    columnIndex++;
                }
            }

            catch (Exception ex)
            {

            }
        }
    }
}