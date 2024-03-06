using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Models;
using QLBH.Business;
using QLBH.Commons;
using static QLBH.Commons.Common_Constants;
using QLBH.Commons.Common_Page;
using CloudinaryDotNet.Actions;

namespace QLBH.Api.Controllers
{
    [Route(DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class AddressReceiveController : ControllerBase
    {
        private readonly IAddressReceive<Respon_AddressReceive, long> _addessReceive;

        public AddressReceiveController(IAddressReceive<Respon_AddressReceive, long> addessReceive)
        {
            _addessReceive = addessReceive;
        }
        [HttpPost()]
        [Authorize]
        public async Task Create([FromBody] Request_AddressReceive request_AddessReceive)
        {
            request_AddessReceive.accountID = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            await _addessReceive.Create(request_AddessReceive);
        }
        [HttpPost("{addressReceiveID}")]
        [Authorize]
        public async Task Update(long addressReceiveID, [FromBody] Request_AddressReceive request_AddressReceive)
        {
            request_AddressReceive.accountID = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            await _addessReceive.Update(addressReceiveID, request_AddressReceive);
        }
        [HttpDelete("{addressReceiveID}")]
        [Authorize]
        public async Task Delete(long addressReceiveID)
        {
            await _addessReceive.Delete(addressReceiveID);
        }
        [HttpGet()]
        [Authorize(Roles = RoleKeyString.Admin)]
        public IActionResult GetAll([FromBody] Request_Pagination request_Pagination)
        {
            return Ok(_addessReceive.GetAll(new Pagination
            {
                PageNumber = request_Pagination.pageNumber,
                PageSize = request_Pagination.pageSize
            }, request_Pagination.keyWord));
        }
        [HttpGet()]
        [Authorize]
        public IActionResult GetByID([FromBody] Request_Pagination request_Pagination)
        {
            return Ok(_addessReceive.GetAll(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)
                                            , new Pagination
                                            {
                                                PageNumber = request_Pagination.pageNumber,
                                                PageSize = request_Pagination.pageSize
                                            }, request_Pagination.keyWord));
        }
    }
}
