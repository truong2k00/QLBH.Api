using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Business;
using QLBH.Business.CMS;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class DetailsCartController : ControllerBase
    {
        private readonly IDetailCartServices _services;

        public DetailsCartController(IDetailCartServices services)
        {
            _services = services;
        }
        [HttpGet("GetAccount")]
        [Authorize(RoleKeyString.User)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetByAccount(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_DetailCart dataRequest_DetailCart)
        {
            return Ok(await _services.Create(dataRequest_DetailCart));
        }
        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> Update(long ID,[FromQuery] DataRequest_DetailCart dataRequest_DetailCart)
        {
            return Ok(await _services.Update(ID,dataRequest_DetailCart));
        }
        [HttpDelete("Delete/{ID}")]
        public async Task<IActionResult> Delete(long ID)
        {
            return Ok(await _services?.Delete(ID));
        }
    }
}
