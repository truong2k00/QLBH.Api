using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Api.Extensions;
using QLBH.Business;
using QLBH.Business.CMS;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationServices _services;

        public NotificationController(INotificationServices services)
        {
            _services = services;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(_services.GetAll());
        }
        [HttpGet("GetAccountID")]
        [Authorize]
        public IActionResult GetByAccount()
        {
            return Ok(_services.GetAll(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_Notification notification)
        {
            await _services.Create(notification);
            return Ok();
        }
        [HttpDelete("Delete/{ID}")]
        public async Task<IActionResult> Delete(long ID)
        {
            await _services.Delete(ID);
            return Ok();
        }
        [HttpPut("Update/{ID}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Editor)]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_Notification notification)
        {
            await _services.Update(ID, notification);
            return Ok();
        }
        [HttpPut("watched/{ID}")]
        public async Task<IActionResult> Watched(long ID)
        {
            return Ok(await _services.Watched(ID));
        }
    }
}
