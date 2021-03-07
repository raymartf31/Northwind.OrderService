using Microsoft.AspNetCore.Mvc;
using Northwind.Ordering.Api.Services;
using System.Threading.Tasks;

namespace Northwind.Ordering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _smsService;

        public SMSController(ISMSService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost("sendsms")]
        public async Task<IActionResult> SendSMS()
        {
            // Twilio test account only allow 1 number registered to receive an SMS.
            await _smsService.Send("+48987", "Hi Oli!");

            return Ok(true);
        }
    }
}
