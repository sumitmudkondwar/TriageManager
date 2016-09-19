using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace DataAccessLayer.BusinessLogic
{
    public static class EmailClient
    {
        public static void SendMail(string to, string from, string name, string subject, string html, string plainText)
        {
            MailMessage mailMsg = new MailMessage();
            mailMsg.To.Add(new MailAddress(to, to.Substring(0, to.IndexOf('@'))));
            mailMsg.From = new MailAddress(from, name);
            mailMsg.Subject = subject;
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(plainText, null, MediaTypeNames.Text.Plain));
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
            SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
            //smtpClient.Send(mailMsg);
        }
    }
}
