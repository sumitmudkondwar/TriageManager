using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class DataAccess
    {
        private static SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        private static SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        /// <method>
        /// Open Database Connection if Closed or Broken
        /// </method>
        private static SqlConnection openConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
            {
                sqlConnection.Open();
            }
            return sqlConnection;
        }

        public static DataTable executeGetDataTable(string Query, SqlParameter[] sqlParameter)
        {
            using (SqlCommand myCommand = new SqlCommand())
            {
                DataTable dataTable = new DataTable();
                dataTable = null;
                DataSet ds = new DataSet();
                try
                {
                    myCommand.Connection = openConnection();
                    myCommand.CommandText = Query;
                    myCommand.Parameters.AddRange(sqlParameter);
                    myCommand.ExecuteNonQuery();
                    sqlDataAdapter.SelectCommand = myCommand;
                    sqlDataAdapter.Fill(ds);
                    dataTable = ds.Tables[0];
                }
                catch (SqlException e)
                {
                    throw new Exception("Exception - Connection.executeSelectQuery - Query: " + Query + " \nException: " + e.StackTrace.ToString());
                }
                return dataTable;
            }
        }

        public static DataTable executeProcGetDataTable(string Query, SqlParameter[] sqlParameter)
        {
            using (SqlCommand sqlCommand = new SqlCommand(Query, openConnection()))
            {
                DataTable dataTable = new DataTable();
                dataTable = null;
                DataSet ds = new DataSet();
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(sqlParameter);
                    sqlCommand.ExecuteNonQuery();
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(ds);
                    dataTable = ds.Tables[0];
                }
                catch (SqlException e)
                {
                    throw new Exception("Exception - Connection.executeSelectQuery - Query: " + Query + " \nException: " + e.StackTrace.ToString());
                }
                return dataTable;
            }
        }

        /// <method>
        /// Insert Query
        /// </method>
        public static int executeInsertQuery(string Query, SqlParameter[] sqlParameter)
        {
            int retval = 0;
            using (SqlCommand sqlCommand = new SqlCommand(Query, openConnection()))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(sqlParameter);
                    retval = sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw new Exception("Exception - Connection.executeInsertQuery - Query: " + Query + " \nException: \n" + e.StackTrace.ToString());
                }
                return retval;
            }
        }

        /// <method>
        /// Update Query
        /// </method>
        public static int executeUpdateQuery(string Query, SqlParameter[] sqlParameter)
        {
            int retval = 0;
            using (SqlCommand sqlCommand = new SqlCommand(Query, openConnection()))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(sqlParameter);
                    retval = sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw new Exception("Exception - Connection.executeUpdateQuery - Query: " + Query + " \nException: " + e.StackTrace.ToString());
                }
                return retval;
            }
        }
    }
}
