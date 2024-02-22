using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Api.Extensions;
using QLBH.Business;
using System.ComponentModel.Design;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers.CMS
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class RefeshTokenController : ControllerBase
    {
        private readonly IRefeshTokenServices _services;

        public RefeshTokenController(IRefeshTokenServices services)
        {
            _services = services;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _services.GetAll(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }
        [HttpGet("GetAll")]
        [Authorize(RoleKeyString.Admin,RoleKeyString.Manager)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAll());
        }
    }
}
