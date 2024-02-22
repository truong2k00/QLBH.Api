using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Common_Constants;
using System.ComponentModel.DataAnnotations;

namespace QLBH.Commons
{
    public class MailHepper
    {
        public static bool IsValidateEmail(string Email)
        {
            var checkEmail = new EmailAddressAttribute();
            return checkEmail.IsValid(Email);
        }
        public class EmailSender
        {
            private readonly IConfiguration _configuration;
            public EmailSender(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public Task SendEmailAsync(string email, string subject, string message)
            {
                var client = new SmtpClient(_configuration.GetSection(AppSettingKeys.AppSettingSMTP).Value,
                                            int.Parse(_configuration.GetSection(AppSettingKeys.AppSettingPort).Value))
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_configuration.GetSection(AppSettingKeys.AppSettingGmail).Value,
                                                        _configuration.GetSection(AppSettingKeys.AppSettingGmailPassword).Value)
                };
                var mailseeding = new MailMessage(from: _configuration.GetSection(AppSettingKeys.AppSettingGmail).Value,
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
}
