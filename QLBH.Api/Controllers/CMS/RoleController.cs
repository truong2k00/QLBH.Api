using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Api.Extensions;
using QLBH.Business;
using QLBH.Business.CMS;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleServices;
        private readonly IDecentralizationServices _decentralizationServices;

        public RoleController(IRoleServices roleServices, IDecentralizationServices decentralizationServices)
        {
            _roleServices = roleServices;
            _decentralizationServices = decentralizationServices;
        }
        [HttpGet]
        [Authorize(RoleKeyString.Admin)]
        public IActionResult GetAll()
        {
            return Ok(_roleServices.GetAll());
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] DataRequest_Role request_Role)
        {
            await _roleServices.UpdateAsync(request_Role);
            return Ok();
        }
        //Decentralization Services
        [HttpPost("Decentralization/Create")]
        [Authorize(RoleKeyString.Admin)]
        public async Task<IActionResult> Create([FromQuery] DataRequest_Decenlization dataRequest_)
        {
            await _decentralizationServices.Create(dataRequest_);
            return Ok();
        }
        [HttpPut("Decentralization/Update/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_Decenlization dataRequest_)
        {
            await _decentralizationServices.Update(ID, dataRequest_);
            return Ok();
        }
        [HttpDelete("Decentralization/Delete/{ID}")]
        public async Task<IActionResult> Delete(long ID)
        {
            await _decentralizationServices.Delete(ID);
            return Ok();
        }
        [HttpGet("Decentralization/GetByID")]
        public IActionResult GetByID()
        {
            return Ok(_decentralizationServices.GetAllRole(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }
        [HttpGet("Decentralization/GetAll")]
        public IActionResult DecentralizationGetAll()
        {
            return Ok(_decentralizationServices.GetAllRole());
        }
    }
}
