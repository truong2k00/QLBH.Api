using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Api.Extensions;
using QLBH.Business.CMS;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryServices _services;

        public ProductCategoryController(IProductCategoryServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAll());
        }
        [HttpPost("Create")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager, RoleKeyString.Editor)]
        public async Task<IActionResult> Create([FromQuery] DataRequest_ProductCategory dataRequest_)
        {
            return Ok(await _services.Create(dataRequest_));
        }
        [HttpPut("Update/{ID}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager, RoleKeyString.Editor)]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_ProductCategory dataRequest_)
        {
            return Ok(await _services.Update(ID, dataRequest_));
        }
        [HttpDelete("Delete/{ID}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager, RoleKeyString.Editor)]
        public async Task<IActionResult> Delete(long ID)
        {
            return Ok(await _services.Delete(ID));
        }
    }
}
