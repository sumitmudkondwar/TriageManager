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
    public partial class TDPTasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
                }

                bindGrid();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTask.Text.Trim().ToString() == string.Empty || txtTopic.Text.Trim().ToString() == string.Empty)
            {
                lblComment.Text = "Topic / Task cannot be blank";
                return;
            }

            string email = HttpContext.Current.User.Identity.Name.ToString();
            
            System.Data.SqlClient.SqlConnection sqlConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            cmd.CommandText = "INSERT INTO [dbo].[Tasks] ([Topic],[Task],[CreatedBy],[CreatedDate]) VALUES ('" +
                txtTopic.Text.ToString() + "','" + txtTask.Text.Replace("\n", " <br>").ToString() + "','" + email.ToString() + "','" + DateTime.Now.ToString() + "')";
            cmd.ExecuteNonQuery();

            sqlConnection.Close();

            lblComment.Text = "New Task with Topic '" + txtTopic.Text.ToString() + "' added.";
            txtTask.Text = string.Empty;
            txtTopic.Text = string.Empty;           

            bindGrid();
        }

        protected void grdTasks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string decodedText = HttpUtility.HtmlDecode(e.Row.Cells[1].Text);
            e.Row.Cells[1].Text = decodedText;
        }

        protected void bindGrid()
        {
            DataSet ds = null;
            SqlDataAdapter sqldda = null;

            System.Data.SqlClient.SqlConnection sqlConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            cmd.CommandText = "SELECT Topic, Task from Tasks";
            ds = new DataSet();
            sqldda = new SqlDataAdapter(cmd);
            sqldda.Fill(ds);

            sqlConnection.Close();

            grdTasks.DataSource = ds.Tables[0];
            grdTasks.DataBind();
        }
    }
}