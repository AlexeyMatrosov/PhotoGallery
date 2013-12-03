using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;
using PhotoGallery.WebUI.Models;

namespace PhotoGallery.WebUI.Email
{
    public class EmailSettings
    {
        public string MailToAddress = "AlexeyMatroskin4@yandex.ru";
        public string MailFromAddress = "Alexey.S.Matrosov@gmail.com";
        public bool UseSsl = true;
        public string Username = "Alexey.S.Matrosov";
        public string Password = "ZWrehEx623";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }

    public class ConcreteMailService : IeMailService
    {
        private EmailSettings emailSetting;
        public ConcreteMailService(EmailSettings settings)
        {
            emailSetting = settings;
        }

        public void SentMessage(EMailModel info)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSetting.UseSsl;
                smtpClient.Host = emailSetting.ServerName;
                smtpClient.Port = emailSetting.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSetting.Username, emailSetting.Password);

                StringBuilder body = new StringBuilder();
                body.AppendLine("Name: " + info.Name);
                body.AppendLine("Email: " + info.Mail);
                body.AppendLine("-----");
                body.AppendLine(info.Body);

                MailMessage mailMessage = new MailMessage(emailSetting.MailFromAddress,
                    emailSetting.MailToAddress,
                    "New comment!",
                     body.ToString());

                smtpClient.Send(mailMessage);
            }
        }
    }
}