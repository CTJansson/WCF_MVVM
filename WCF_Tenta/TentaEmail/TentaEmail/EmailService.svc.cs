using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TentaEmail
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmailService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmailService.svc or EmailService.svc.cs at the Solution Explorer and start debugging.
    public class EmailService : IEmailService
    {
        private static string SMTPSERVER = "smtp.gmail.com";
        private static int PORTNO = 587;
        private NewsAppEnts ctx;

        public EmailService()
        {
            ctx = new NewsAppEnts();
        }

        public void SendEmailToSubscribers(string header)
        {
            string gmailUserName = "wcftenta@gmail.com";
            string gmailPassword = "";
            string subject = "Newsapp Subscription Mail";
            string body = "A new newspost has been added" + "\n\n " + "Header: " + header + "\nSounds interesting? Check out the app to read it's content!";
            bool isBodyHtml = false;

            SmtpClient smtpClient = new SmtpClient(SMTPSERVER, PORTNO);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(gmailUserName, gmailPassword);
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(gmailUserName);
                message.Subject = subject == null ? "" : subject;
                message.Body = body == null ? "" : body;
                message.IsBodyHtml = isBodyHtml;

                List<SubscribedEmail> emailsToMessage = ctx.SubscribedEmails.ToList();

                foreach (SubscribedEmail email in emailsToMessage)
                {
                    message.To.Add(email.Email);
                }
                try
                {
                    smtpClient.Send(message);
                }
                catch
                {

                }
            }
        }
    }
}
