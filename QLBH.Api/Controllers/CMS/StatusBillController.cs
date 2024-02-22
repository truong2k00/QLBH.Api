using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.TeamFoundation;
using QLBH.Business;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class StatusBillController : ControllerBase
    {
        private readonly IStatusBillsServices _services;

        public StatusBillController(IStatusBillsServices services)
        {
            _services = services;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAll());
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_StatusBill dataRequest_)
        {
            return Ok(await _services.Create(dataRequest_));
        }
        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_StatusBill dataRequest_)
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
