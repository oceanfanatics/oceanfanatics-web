using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics
{
    public class SendEmail 
    {
        private readonly IConfiguration _config;

        public SendEmail(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> Send(string subject, string to, string msg)
        {
            string sendgridapikey = Convert.ToString(_config["Cofoundry:Mail:SendgridApiKey"]);
            
            var apiKey = sendgridapikey;
            var client = new SendGridClient(apiKey);
            var fromAddress = new EmailAddress(Convert.ToString(_config["Cofoundry:Mail:DefaultFromAddress"]), Convert.ToString(_config["Cofoundry:Mail:DefaultFromName"]));
            var toAddress = new EmailAddress(to);
            var msgA = MailHelper.CreateSingleEmail(fromAddress, toAddress, subject, msg, msg);
            var response = await client.SendEmailAsync(msgA);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
