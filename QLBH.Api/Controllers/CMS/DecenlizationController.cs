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
    public class DecenlizationController : ControllerBase
    {
        private readonly IDecentralizationServices _services;

        public DecenlizationController(IDecentralizationServices services)
        {
            _services = services;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_Decenlization dataRequest_)
        {
            return Ok(await _services.Create(dataRequest_));
        }
        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_Decenlization dataRequest_)
        {
            return Ok(await _services.Update(ID, dataRequest_));
        }
        [HttpDelete("Delete/{ID}")]
        public async Task<IActionResult> Delete(long ID)
        {
            return Ok(await _services.Delete(ID));
        }
        [HttpGet("GetByID")]
        public IActionResult GetByID()
        {
            return Ok(_services.GetAllRole(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_services.GetAllRole());
        }
    }
}
