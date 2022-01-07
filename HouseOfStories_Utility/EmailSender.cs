using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace HouseOfStories_Utility
{
    public class EmailSender : IEmailSender
    {
       private readonly IConfiguration _config;

        public EmailSender(IConfiguration configuration)
        {
            _config = configuration;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        public async Task Execute(string email, string subject, string body)
        {
            var _mailJetSettings = _config.GetSection("MailJet").Get<MailJetSettings>();
            MailjetClient client = new MailjetClient(_mailJetSettings.ApiKey,_mailJetSettings.SecretKey)
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
     new JObject {
      {
       "From",
       new JObject {
        {"Email", "petr616@yandex.ru"},
        {"Name", "Егор"}
       }
      }, {
       "To",
       new JArray {
        new JObject {
         {
          "Email",
         email
         }, {
          "Name",
          "Егор"
         }
        }
       }
      }, {
       "Subject",
       subject
      },
         {
       "HTMLPart",
         body
      }
     }
             });
           await client.PostAsync(request);
        }
    }
}
