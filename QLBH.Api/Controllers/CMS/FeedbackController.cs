using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Business;
using QLBH.Models;
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
        public async Task<IActionResult> Create([FromBody] Request_Feedback feedback)
        {
            feedback.accountId = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            return Ok(await _feedbackServices.Create(feedback));
        }
        [HttpPut("Update/{AddressID}")]
        public async Task<IActionResult> Update(long AddressID, [FromBody] Request_Feedback feedback)
        {
            return Ok(await _feedbackServices.Update(AddressID, feedback));
        }
        [HttpDelete("Delete/{AddressID}")]
        public async Task<IActionResult> Delete(long AddressID)
        {
            return Ok(await _feedbackServices.Delete(AddressID));
        }
    }
}
