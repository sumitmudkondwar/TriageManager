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
                    new SqlParameter("@p_SmeTopicsId", triageContent.SmeTopicsId),
                    new SqlParameter("@p_ContentLevel", triageContent.ContentLevel),
                    new SqlParameter("@p_ContentDescription", triageContent.ContentDescription),
                    new SqlParameter("@p_EmailId", triageContent.EmailId),
                    new SqlParameter("@p_FileNameList", triageContent.FileNameList),
                    new SqlParameter("@p_ContentURL", triageContent.ContentURL),
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
            dt = DataAccess.DataAccess.executeGetDataTable("select MainContentId,TopicName[ContentHeading],ContentLevel,ContentDescription,ContentGUID, FirstName + ' ' + LastName 'Contributor' from MainContent MC inner join users US on (MC.emailid = US.EmailID) inner join SmeTopics sme on (MC.SmeTopicsId = sme.SmeTopicsId)", sqlParameter);

            return dt;
        }

        public DataTable GetSMETopics()
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_Alias", "test"),
                };
            dt = DataAccess.DataAccess.executeGetDataTable("select SmeTopicsId,TopicName from SmeTopics", sqlParameter);

            return dt;
        }

        public DataTable GetTriageContentsGUID(string GUID)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_ContentGUID", GUID),
                };
            dt = DataAccess.DataAccess.executeGetDataTable("select MainContentId,ContentHeading,ContentDescription,ContentGUID, FirstName + ' ' + LastName 'Contributor' from MainContent MC inner join users US on (MC.emailid = US.EmailID) where ContentGUID = @p_ContentGUID", sqlParameter);

            return dt;
        }

        public DataTable GetTriageContentsFiles(string GUID)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_ContentGUID", GUID),
                };
            dt = DataAccess.DataAccess.executeGetDataTable("select BlobPath, BlobPath from FileNameContent where ContentGUID = @p_ContentGUID", sqlParameter);

            return dt;
        }

        public DataTable GetContentsFiles(string SmeTopicsId, string ContentLevel)
        {
            DataTable dt = new DataTable();
            string Query = "select ROW_NUMBER() OVER(ORDER BY [Contents] DESC) AS Row,[Contents],[Contents],[Type],[ContentDescription] from (";
            Query = Query + "select Blobpath [Contents],'Files'[Type],[ContentDescription][ContentDescription] from FileNameContent FC inner join MainContent MC on (FC.ContentGUID = MC.ContentGUID) where SmeTopicsId = @p_SmeTopicsId and ContentLevel = @p_ContentLevel ";
            Query = Query + " Union ";
            Query = Query + " select ContentURL [Contents], 'Urls'[Type],ContentDescription[ContentDescription] from MainContent where ContentURL != '' and SmeTopicsId = @p_SmeTopicsId and ContentLevel = @p_ContentLevel)a";
            //Query = Query + " ";

            SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@p_SmeTopicsId", SmeTopicsId),
                    new SqlParameter("@p_ContentLevel", ContentLevel),
                };
            dt = DataAccess.DataAccess.executeGetDataTable(Query, sqlParameter);

            return dt;
        }
    }
}
