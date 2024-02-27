using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Business;
using QLBH.Models;
using System.Net.Security;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackServices<Response_Feedback> _feedbackServices;

        public FeedbackController(IFeedbackServices<Response_Feedback> feedbackServices)
        {
            _feedbackServices = feedbackServices;
        }
        [HttpPost("Create")]
        [Authorize]
        public async Task Create([FromBody] Request_Feedback feedback)
        {
            feedback.accountID = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            await _feedbackServices.Create(feedback);
        }
        [HttpPut("Update/{AddressID}")]
        [Authorize]
        public async Task Update(long AddressID, [FromBody] Request_Feedback feedback)
        {
            feedback.accountID = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            await _feedbackServices.Update(AddressID, feedback);
        }
        [HttpDelete("Delete/{AddressID}")]
        [Authorize(RoleKeyString.Admin)]
        public async Task Delete(long AddressID)
        {
            await _feedbackServices.Delete(AddressID);
        }
        [HttpGet("Get")]
        public IActionResult Get([FromQuery] long acountId = 0, [FromQuery] long productID = 0)
        {
            return Ok(_feedbackServices.GetAll(acountId, productID));
        }
    }
}
