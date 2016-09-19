using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.BusinessLogic
{
    public class TriagePollLogic
    {
        public int SubmitPoll(TriagePoll triagePoll)
        {
            int retval = 0;
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_IsTriageAttended", triagePoll.IsTriageAttended),
                    new SqlParameter("@p_Alias", triagePoll.Alias),
                    new SqlParameter("@p_TriageLevel", triagePoll.TriageLevel),
                    new SqlParameter("@p_TriageQuality", triagePoll.TriageQuality),
                    new SqlParameter("@p_Presentation", triagePoll.Presentation),
                    new SqlParameter("@p_Comments", triagePoll.Comments),
                    new SqlParameter("@p_Reason", triagePoll.Reason),
                    new SqlParameter("@p_TriageDate", triagePoll.TriageDate),
                };

                retval = DataAccess.DataAccess.executeInsertQuery("pr_InsertPoll", sqlParameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;
        }

        public DataTable GetTriageCalender()
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_Alias", "test"),
                };
            dt = DataAccess.DataAccess.executeProcGetDataTable("pr_getTriageCalender", sqlParameter);

            return dt;
        }

        public DataTable GetTriageContents()
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_Alias", "test"),
                };
            dt = DataAccess.DataAccess.executeGetDataTable("select url, type, topic from Contents", sqlParameter);

            return dt;
        }

        public DataTable GetReportTriageAttended(string alias)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_Alias", alias),
                };
            dt = DataAccess.DataAccess.executeGetDataTable("select Alias, TriageDate [Date], TriageLevel [Level],TriageQuality [Quality], Presentation, Comments, Reason from poll", sqlParameter);

            return dt;
        }

        public DataTable GetTriageDate(bool type)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_type", type),
                };
            dt = DataAccess.DataAccess.executeProcGetDataTable("get_TriageDate", sqlParameter);

            return dt;
        }

        public bool PollValidation(string UserID, DateTime Date)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_UserID", UserID),
                    new SqlParameter("@p_Date", Date),
                };
            dt = DataAccess.DataAccess.executeGetDataTable("select count(*)[Count] from poll where alias = @p_UserID and TriageDate = @p_Date", sqlParameter);

            if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
            {
                return false;
            }
            return true;
        }

        public DataTable GetDashboardData()
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameter = new SqlParameter[]{new SqlParameter("@p_type", ""),};
            dt = DataAccess.DataAccess.executeProcGetDataTable("pr_DashBoard", sqlParameter);

            return dt;
        }

        public DataTable GetFeedBackPending(string alias)
        {
            DataTable dt = new DataTable();
            string Query = "pr_GetFeedbackPending";
            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_Alias", alias),
                };
            dt = DataAccess.DataAccess.executeProcGetDataTable(Query, sqlParameter);

            return dt;
        }

        public DataTable YourTriages(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_Alias", name),
                };
            dt = DataAccess.DataAccess.executeProcGetDataTable("pr_getYourTriages", sqlParameter);

            return dt;
        }

        public bool GetValidTriageDate(string TriageDate)
        {
            try
            {
                DateTime TriageDateNew = Convert.ToDateTime(TriageDate);

                if (TriageDateNew > DateTime.Today.Date)
                    return false;

                DataTable dt = new DataTable();
                string Query = "select count(*)[Count] from TriageCalender where TriageDate = @p_TriageDate";
                SqlParameter[] sqlParameter = new SqlParameter[]
                    {
                        new SqlParameter("@p_TriageDate", TriageDateNew),
                    };
                dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);

                if (Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetReportNameList(string Alias, out string Designation)
        {
            try
            {
                DataTable dt = new DataTable();

                string Query = "select designation from users where EmailID = @p_EmailID";

                SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@p_EmailID", Alias) };
                dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);
                Designation = string.Empty;

                if (dt != null && dt.Rows.Count > 0)
                {
                    Designation = dt.Rows[0][0].ToString();

                    if (dt.Rows[0][0].ToString().Equals("TA") || dt.Rows[0][0].ToString().Equals("Manager"))
                    {
                        dt = new DataTable();
                        Query = "select FirstName + ' ' + LastName [Name], Alias from users order by [Name]";
                        sqlParameter = new SqlParameter[]
                        {
                        new SqlParameter("@p_Alias", Alias),
                        };
                        dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);
                    }
                    else
                        dt = null;
                }
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetTriageDateList(string Alias)
        {
            try
            {
                DataTable dt = new DataTable();

                string Query = "select REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[TriageDate] from TriageCalender where Team1Member = @Alias or Team2Member = @Alias or TA_Member = @Alias or TriageMentor = @Alias";

                SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@Alias", Alias) };
                dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);
                
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReportData(string TriageDate, string ReportType, string Designation)
        {
            DataTable dt = new DataTable();

            string Query = string.Empty;

            if (ReportType.Equals("1"))
            {
                if(Designation.Equals("Manager"))
                    Query = "select us.FirstName + ' ' + us.LastName [Name], us.Alias, us.EmailID [Email ID], ";
                else
                    Query = "select ";

                Query = Query + " IsTriageAttended,TriageLevel [Triage Level],TriageQuality [Triage Quality],Presentation,Comments,Reason ";
                Query = Query + " from poll po inner join users us on (po.alias = us.emailid)";
                Query = Query + " where TriageDate = @p_TriageDate ";
            }
            //else if (ReportType.Equals("2"))
            //{
            //    Query = "select us.FirstName + ' ' + us.LastName [Name], us.Alias, us.EmailID [Email ID], Reason from poll po ";
            //    Query = Query + " inner join users us on (po.alias = us.emailid)";
            //    Query = Query + " where TriageDate = @p_TriageDate and IsTriageAttended='No'";
            //}
            else if (ReportType.Equals("2"))
            {
                Query = "select FirstName + ' ' + LastName[List of Engineers Not Submitted Poll],EmailID [Email ID],Alias from Users where EmailID not in (select Alias from poll where TriageDate = @p_TriageDate)";
            }
                        
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@p_TriageDate", TriageDate) };
            dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);
            
            return dt;
        }

        public DataTable GetReportDataForAll(string EmailID)
        {
            DataTable dt = new DataTable();

            string Query = "declare @Alias varchar(50); select @Alias = Alias from Users where EmailID = @p_EmailID;";
            Query = Query + " select TriageLevel,TriageQuality,Presentation,Comments from poll where TriageDate = (select top 1 TriageDate from TriageCalender ";
            Query = Query + " where (Team1Member = @Alias or Team2Member = @Alias or TA_Member = @Alias or TriageMentor = @Alias) and IsTriageAttended='Yes')";

            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@p_EmailID", EmailID) };
            dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);

            return dt;
        }

        public string GetTriageOwnerNames(string TriageDate)
        {
            string TriageOwner = "";
            DataTable dt = new DataTable();

            string Query = string.Empty;

            Query = "select firstname + ' ' + lastname [Engineer] from triagecalender tc inner join users us on (tc.team1member=us.alias or tc.team2member=us.alias or tc.TA_Member=us.alias) where triagedate = @p_TriageDate";

            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@p_TriageDate", TriageDate) };
            dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (TriageOwner.Equals(string.Empty))
                    {
                        TriageOwner = dr[0].ToString();
                    }
                    else
                    {
                        TriageOwner = TriageOwner + ", " + dr[0].ToString();
                    }
                }
            }

            return TriageOwner;
        }

        public string GetUserName(string EmailId)
        {
            string UserName = "";
            DataTable dt = new DataTable();

            string Query = string.Empty;

            Query = "select firstname + ' ' + lastname[UserName] from users where emailid = @p_EmailId";

            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@p_EmailId", EmailId) };
            dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);

            if (dt != null && dt.Rows.Count > 0)
            {
                UserName = dt.Rows[0][0].ToString();
            }

            return UserName;
        }
    }
}
