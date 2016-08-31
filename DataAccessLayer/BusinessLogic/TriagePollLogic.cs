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
            dt = DataAccess.DataAccess.executeGetDataTable("select REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[Triage Date], TriageTopic [Topic], Team1Member [Team 1], Team2Member [Team 2], TA_Member [TA], TriageMentor [Mentor] from TriageCalender", sqlParameter);

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

        public DataTable YourTriages(string name)
        {
            DataTable dt = new DataTable();
            string Query = "declare @name varchar(50) select @name = alias from users where emailid = @p_Alias";
            Query = Query + " select REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[Triage Date], TriageTopic [Triage Topic], Team1Member [Team1 Member], Team2Member [Team2 Member], TA_Member [TA Member], TriageMentor[Triage Mentor]";
            Query = Query + " from triagecalender where team1member = @name or team2member = @name or ta_member = @name or triagementor = @name";
            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_Alias", name),
                };
            dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);

            return dt;
        }
    }
}
