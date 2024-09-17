using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Ginilytics.Model.ViewModel;
using Ginilytics.Service.Services.Contracts;

namespace Ginilytics.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly AppSettings _appSettings;
        public EmailService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        /// <summary>
        /// It will be a common code to send email 
        /// </summary>
        /// <param name="emailBody"></param>
        /// <param name="sendTo"></param>
        public void SendEmail(string sendToMailAddress, string emailBody, string subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(_appSettings.smtpFromEmail);
                message.To.Add(new MailAddress(sendToMailAddress));
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = emailBody;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_appSettings.smtpFromEmail, _appSettings.smtpPassword);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// It will return email template as per its type
        /// </summary>
        /// <param name="tempType">template you want send</param>
        /// <returns></returns>
        public string GetEmailTemplate()
        {
            StringBuilder storeContent = new StringBuilder();
            string message = string.Empty;
            try
            {
                message = "Hello {userName}! Your password is for Ginilytics is: . Thanks!";
            }
            catch (Exception objError)
            {
                throw objError;
            }
            return message;
        }


    }
}
