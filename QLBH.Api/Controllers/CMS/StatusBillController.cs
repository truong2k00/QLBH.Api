using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.TeamFoundation;
using QLBH.Business;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class StatusBillController : ControllerBase
    {
        private readonly IStatusBillsServices _services;

        public StatusBillController(IStatusBillsServices services)
        {
            _services = services;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_services.GetAll());
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_StatusBill dataRequest_)
        {
            await _services.Create(dataRequest_);
            return Ok();
        }
        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_StatusBill dataRequest_)
        {
            await _services.Update(ID, dataRequest_);
            return Ok();
        }
        [HttpDelete("Delete/{ID}")]
        public async Task<IActionResult> Delete(long ID)
        {
            await _services.Delete(ID);
            return Ok();
        }
    }
}
