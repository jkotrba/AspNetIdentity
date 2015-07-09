using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using SendGrid;
using System.Net;
using System.Configuration;

namespace AspNetIdentity.WebApi.Services
{
    public class EmailService: IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridAsync(message);
        }

        private async Task configSendGridAsync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();

            myMessage.AddTo(message.Destination);
            myMessage.From = new System.Net.Mail.MailAddress("jerome.kotrba@aspnetidentity.com", "Jerome Kotrba");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;

            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailService:Account"],
                ConfigurationManager.AppSettings["emailService:Password"]);

            // Create a Web transport for sending mail.
            var transportWeb = new Web(credentials);

            // Send the email
            if(transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                // Trace.TraceError("Failed to create web transport");
                await Task.FromResult(0);
            }
        }
    }
}