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
            await _feedbackServices.Create(feedback);
            return Ok();
        }
        [HttpPut("Update/{AddressID}")]
        public async Task<IActionResult> Update(long AddressID,[FromBody] Request_Feedback feedback)
        {
            await _feedbackServices.Update(AddressID, feedback);
            return Ok();
        }
        [HttpDelete("Delete/{AddressID}")]
        public async Task<IActionResult> Delete(long AddressID)
        {
            await _feedbackServices.Delete(AddressID);
            return Ok();
        }
    }
}
