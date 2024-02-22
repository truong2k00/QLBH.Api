using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Api.Extensions;
using QLBH.Business;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly IInvoiceDetailsServices _Services;

        public InvoiceDetailsController(IInvoiceDetailsServices services)
        {
            _Services = services;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_InvoidDetails dataRequest_)
        {
            return Ok(await _Services.Create(dataRequest_));
        }
        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_InvoidDetails dataRequest_)
        {
            return Ok(await _Services.Update(ID, dataRequest_));
        }
        [HttpDelete("Delete/{ID}")]
        public async Task<IActionResult> Delete(long ID)
        {
            return Ok(await _Services.Delete(ID));
        }
        [HttpGet("GetAllBill/{IDBill}")]
        public async Task<IActionResult> Get(long IDBill)
        {
            return Ok(await _Services.GetByIDBill(IDBill));
        }
        [HttpGet("GetAllBill")]
        [Authorize(RoleKeyString.Admin)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _Services.GetAll());
        }
    }
}
