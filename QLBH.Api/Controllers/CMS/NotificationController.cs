using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Api.Extensions;
using QLBH.Business;
using QLBH.Business.CMS;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationServices _services;

        public NotificationController(INotificationServices services)
        {
            _services = services;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _services.GetAll());
        }
        [HttpGet("GetAccountID")]
        [Authorize]
        public async Task<IActionResult> GetByAccount()
        {
            return Ok(await _services.GetByAccount(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_Notification notification)
        {
            return Ok(await _services.Create(notification));
        }
        [HttpDelete("Delete/{ID}")]
        public async Task<IActionResult> Delete(long ID)
        {
            return Ok(await _services.Delete(ID));
        }
        [HttpPut("Update/{ID}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Editor)]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_Notification notification)
        {
            return Ok(await _services.Update(ID, notification));
        }
        [HttpPut("watched/{ID}")]
        public async Task<IActionResult> Watched(long ID)
        {
            return Ok(await _services.Watched(ID));
        }
    }
}
