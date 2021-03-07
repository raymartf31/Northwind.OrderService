using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Northwind.Ordering.Api.Services
{
    public class SMSService : ISMSService
    {
        private readonly IConfiguration _configuration;
        public SMSService(IConfiguration configruation)
        {
            _configuration = configruation;
        }

        public async Task Send(string phoneNumber, string message)
        {
            string accountSid = _configuration["Twilio:TwilioAccountId"];
            string authToken = _configuration["Twilio:TwilioAuthToken"];
            string fromPhoneNumber = _configuration["Twilio:TwilioPhoneNumber"];

            TwilioClient.Init(accountSid, authToken);

            await MessageResource.CreateAsync(
                body: message,
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
        }
    }
}
