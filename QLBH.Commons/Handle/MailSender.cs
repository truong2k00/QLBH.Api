using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Commons
{
    public class MailSender
    {
        private readonly IConfiguration _configuration;
        public MailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var a = _configuration.GetSection(Common_Constants.AppSettingKeys.AppSettingPort).Value;
            var client = new SmtpClient("Smtp.gmail.com",
                                        587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("tbxuan611@gmail.com",
                                                    "rkuaiiybxkkaojwr")
            };
            var mailseeding = new MailMessage(from: "tbxuan611@gmail.com",
                                                        to: email,
                                                        subject,
                                                        body: message)
            {
                IsBodyHtml = true
            };
            return client.SendMailAsync(mailseeding);
        }
    }
}
