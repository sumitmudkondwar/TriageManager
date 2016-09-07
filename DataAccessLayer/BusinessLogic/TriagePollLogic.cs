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
            string Query = "select REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[Triage Date],TriageTopic,Team1Member [Team1 Member],";
            Query = Query + "Team2Member [Team2 Member],TA_Member[TA Member],TriageMentor[Triage Mentor],'Submit Poll'[Submit Poll],'Triage Contents'[Triage Contents]";
            Query = Query + " from (select datediff(day, triagedate, getdate())[day1], triagedate,getdate()[customdate],TriageTopic,Team1Member,Team2Member,TA_Member,TriageMentor from triagecalender) a";
            Query = Query + " where day1 > 0 AND [TriageDate] NOT IN (select REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[Triage Date] from poll where alias = @p_Alias)";
            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_Alias", alias),
                };
            dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);

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

        public DataTable GetReportNameList(string Alias)
        {
            try
            {
                DataTable dt = new DataTable();

                string Query = "select designation from users where EmailID = @p_EmailID";

                SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@p_EmailID", Alias) };
                dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);

                if (dt.Rows[0][0].ToString().Equals("TA"))
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

        public DataTable GetReportData(string TriageDate)
        {
            DataTable dt = new DataTable();

            string Query = "select Alias,IsTriageAttended,TriageLevel,TriageQuality,Presentation,Comments,Reason from poll where TriageDate = @p_TriageDate";
            
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@p_TriageDate", TriageDate) };
            dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);
            
            return dt;
        }

        public DataTable GetReportDataForAll(string EmailID)
        {
            DataTable dt = new DataTable();

            string Query = "declare @Alias varchar(50); select @Alias = Alias from Users where EmailID = @p_EmailID;";
            Query = Query + " select IsTriageAttended,TriageLevel,TriageQuality,Presentation,Comments,Reason,REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[TriageDate] from poll where TriageDate = (select top 1 TriageDate from TriageCalender ";
            Query = Query + " where Team1Member = @Alias or Team2Member = @Alias or TA_Member = @Alias or TriageMentor = @Alias)";

            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@p_EmailID", EmailID) };
            dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);

            return dt;
        }
    }
}
