using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Commons;
using QLBH.Models;
using QLBH.Business;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Request_Login request_Login)
        {
            return Ok(await _authServices.Login(request_Login));
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Request_Register request_Register)
        {
            return Ok(await _authServices.Register(request_Register));
        }
        [HttpGet("ReNewToken")]
        public async Task<IActionResult> RenewToken([FromQuery] string token)
        {
            return Ok(await _authServices.RenewToken(token));
        }
        [HttpPost("Verification")]
        [Authorize]
        public async Task<IActionResult> Verification([FromForm] string code)
        {
            return Ok(await _authServices.ConfirmCode(HttpContext.User.FindFirst(Clames.USER).Value, code));
        }
        [HttpPost("NewCode")]
        public async Task<IActionResult> NewCode([FromForm] string Username)
        {
            return Ok(await _authServices.Create_Code(Username));
        }
    }
}
