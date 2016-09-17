using System;
using DataAccessLayer.BusinessLogic;

namespace TriageManager.Triage
{
    public partial class EmailSender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = @"<!DOCTYPE html><html><head><title></title><meta charset=""utf - 8"" /></head><body><div><p>Sumit HTML Page Latest</p></div></body></html>";
            string plainText = "";
            string subject = "Subject";
            EmailClient.SendMail("vinku@microsoft.com", "sumudk@microsoft.com", "SumitM", subject, html, plainText);
        }
    }
}