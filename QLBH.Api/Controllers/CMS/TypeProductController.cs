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
        public IActionResult GetAll()
        {
            return Ok(_services.GetAll());
        }
        [HttpGet("GetAll/{IDproduct}")]
        public IActionResult GetAll(long IDproduct)
        {
            return Ok(_services.GetAll(IDproduct));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_TypeProduct dataRequest_)
        {
            await _services.Create(dataRequest_);
            return Ok();
        }
        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_TypeProduct dataRequest_)
        {
            await _services.Update(ID, dataRequest_);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _services.Delete(id);
            return Ok();
        }
    }
}
