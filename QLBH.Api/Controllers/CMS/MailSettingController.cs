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
    public class MailSettingController : ControllerBase
    {
        private readonly IMailSettingServices _mailSettingServices;

        public MailSettingController(IMailSettingServices mailSettingServices)
        {
            _mailSettingServices = mailSettingServices;
        }

        [HttpGet("GetAll")]
        [Authorize(RoleKeyString.Admin)]
        public IActionResult GetAll()
        {
            return Ok(_mailSettingServices.GetAllMail());
        }
        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_MailSetting mailSetting)
        {
            await _mailSettingServices.Update(ID, mailSetting);
            return Ok();
        }
    }
}
