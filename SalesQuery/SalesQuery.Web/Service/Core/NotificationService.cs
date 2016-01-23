using SalesQuery.Web.Service.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SalesQuery.Web.Service
{
    public class NotificationService : INotificationService
    {
        // handle notifications like email, sms, etc

        public void SendEmailToSalesTeam(string body)
        {
            var to = ConfigurationManager.AppSettings["SalesEmail"].ToString();
            var from = ConfigurationManager.AppSettings["EmailFrom"].ToString();
            var host = ConfigurationManager.AppSettings["SMTPHost"].ToString();

            string subject = "Sales pricing Query";

            SendEmail(to, from, host, body, subject);
        }


        public void SendEmail(string to, string from, string host, string body, string subject)
        {
            try
            {
                MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(to);
                message.Subject = subject;
                message.From = new System.Net.Mail.MailAddress(from);
                message.Body = body;

                //
                //uncomment the send lines once the email host setupded correctly

                //SmtpClient smtp = new System.Net.Mail.SmtpClient(host);
                //smtp.Send(message);
            }
            catch (Exception)
            {
                // Email Exceptions
                // Log your exception message here
                // Pass the log message to developer
                // Can use log4net etc
            }
        }
    }
}