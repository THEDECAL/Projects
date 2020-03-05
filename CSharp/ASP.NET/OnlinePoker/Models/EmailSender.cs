using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OnlinePoker.Models
{
    public class EmailSender : IEmailSender
    {
        private readonly string _senderMailAddress = "fortestingfortesting@outlook.com";
        //"fortestingfortestingfor@gmail.com";
        private readonly string _senderMailPassword = "5u#[qo8>";
        private readonly SmtpClient _smtpClient;

        public EmailSender()
        {
            try
            {
                _smtpClient = new SmtpClient("SMTP.Office365.com", 587);
                //_smtpClient = new SmtpClient("smtp.gmail.com", 587);
                _smtpClient.Credentials = new NetworkCredential(_senderMailAddress, _senderMailPassword);
                _smtpClient.EnableSsl = true;
            }
            catch (Exception) {  }
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            if (email != null && subject != null && htmlMessage != null)
            {
                var srcMailAddress = new MailAddress(_senderMailAddress);
                var dstMailAddress = new MailAddress(email);
                var msg = new MailMessage(srcMailAddress, dstMailAddress);

                msg.Subject = subject;
                msg.Body = htmlMessage;
                msg.IsBodyHtml = true;

                try
                {
                    await Task.Run(() => _smtpClient.Send(msg));
                }
                catch (Exception) { }
            }
            else throw new NullReferenceException();
        }
    }
}
