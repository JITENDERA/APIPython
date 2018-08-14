using System;

using System.Net.Mail;
using System.Net;


namespace APIPython
{
    public class SendEmails
    {
        public void sendEmail(String htmlBody, Parameters items)
        {


            var fromAddress = new MailAddress(items.frm);
            var fromPassword = items.password;
            var toAddress = new MailAddress(items.to);
            string subject = items.subject;

            // string MailBody = body.MailBodyData(dt);


            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = htmlBody

            })

                smtp.Send(message);


        }
    }
}
