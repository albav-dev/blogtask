using Blog.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _settings;
        private readonly SmtpClient _client;

        public void Send(string from, string to, string subject, string html)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            //using (var smtp = new SmtpClient())
            //{

            //    smtp.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
            //    smtp.Authenticate("xhonibora97@gmail.com", "ketu vendoset password");
            //    smtp.Send(email);
            //    smtp.Disconnect(true);
            //}
        }
    }
}
