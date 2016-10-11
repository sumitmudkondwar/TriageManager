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
    public class TriageContentLogic
    {
        public int AddNewContent(TriageContent triageContent)
        {
            int retval = 0;
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_ContentHeading", triageContent.ContentHeading),
                    new SqlParameter("@p_ContentDescription", triageContent.ContentDescription),
                    new SqlParameter("@p_EmailId", triageContent.EmailId),
                    new SqlParameter("@p_FileNameList", triageContent.FileNameList),
                };

                retval = DataAccess.DataAccess.executeInsertQuery("pr_addNewContent", sqlParameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;
        }

        public DataTable GetTriageContents()
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_Alias", "test"),
                };
            dt = DataAccess.DataAccess.executeGetDataTable("select MainContentId,ContentHeading,ContentDescription,ContentGUID, FirstName + ' ' + LastName 'Contributor' from MainContent MC inner join users US on (MC.emailid = US.EmailID)", sqlParameter);

            return dt;
        }
    }
}
