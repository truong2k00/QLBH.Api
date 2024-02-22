using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Business;
using QLBH.Models;
using QLBH.Models.Entities;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class TypeProductController : ControllerBase
    {
        private readonly ITypeProductServices _services;

        public TypeProductController(ITypeProductServices services)
        {
            _services = services;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAll());
        }
        [HttpGet("GetAll/{IDproduct}")]
        public async Task<IActionResult> GetAll(long IDproduct)
        {
            return Ok(await _services.GetByIDProduct(IDproduct));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_TypeProduct dataRequest_)
        {
            return Ok(await _services.Create(dataRequest_));
        }
        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_TypeProduct dataRequest_)
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
