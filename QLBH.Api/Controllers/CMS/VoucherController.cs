using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Api.Extensions;
using QLBH.Business;
using QLBH.Commons;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers.CMS
{
    [Route(DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherServices _services;

        public VoucherController(IVoucherServices services)
        {
            _services = services;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(_services.GetAll());
        }
        [HttpGet("GetByIDAccount")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager)]
        public IActionResult GetByAccount()
        {
            return Ok(_services.GetAll(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }
        [HttpGet("GetByID/{ID}")]
        [Authorize]
        public IActionResult GetByID(long ID)
        {
            return Ok(_services.GetByID(ID));
        }
        [HttpPost("Create")]
        [Authorize(RoleKeyString.Manager, RoleKeyString.Editor, RoleKeyString.Moderator)]
        public async Task<IActionResult> Create([FromQuery] DataRequest_Voucher dataRequest_)
        {
            dataRequest_.accountID = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            await _services.Create(dataRequest_);
            return Ok();
        }
        [HttpPut("Update/{ID}")]
        [Authorize(RoleKeyString.Manager, RoleKeyString.Editor)]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_Voucher dataRequest_)
        {
            dataRequest_.accountID = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            await _services.Update(ID, dataRequest_);
            return Ok();
        }
        [HttpDelete("Delete/{ID}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager, RoleKeyString.Editor)]
        public async Task<IActionResult> Delete(long ID)
        {
            await _services.Delete(ID);
            return Ok();
        }
    }
}
