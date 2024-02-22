using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Api.Extensions;
using QLBH.Business;
using QLBH.Commons;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class ConfirmEmailController : ControllerBase
    {
        private readonly IConfirmEmail _confirmEmail;

        public ConfirmEmailController(IConfirmEmail confirmEmail)
        {
            _confirmEmail = confirmEmail;
        }

        [HttpGet]
        [Authorize(RoleKeyString.Admin)]
        public IActionResult GetAll()
        {
            return Ok(_confirmEmail.GetAll(Convert.ToInt64(HttpContext.User.FindFirst(Clames.ID).Value)));
        }
        [HttpPut("ConfirmEmail/{Code}")]
        [Authorize]
        public async Task<IActionResult> Confirm(int Code)
        {
            return Ok(await _confirmEmail.ConfirmEmail(HttpContext.User.FindFirst(Clames.USER).Value,Code));
        }
    }
}
