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
    public class DetailsProductController : ControllerBase
    {
        private readonly IDetailProductServices _services;

        public DetailsProductController(IDetailProductServices services)
        {
            _services = services;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_DetailProduct dataRequest_)
        {
            return Ok(await _services.Create(dataRequest_));
        }
        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_DetailProduct dataRequest_)
        {
            return Ok(await _services.Update(ID, dataRequest_));
        }
        [HttpDelete("Delete/{ID}")]
        public async Task<IActionResult> Delete(long ID)
        {
            return Ok(await _services.Delete(ID));
        }
    }
}
