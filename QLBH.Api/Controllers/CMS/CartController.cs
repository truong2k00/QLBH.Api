using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Api.Extensions;
using QLBH.Business;
using QLBH.Business.CMS;
using QLBH.Commons;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(Common_Constants.AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;
        private readonly IDetailCartServices _detailCartServices;

        public CartController(ICartServices cartServices, IDetailCartServices detailCartServices)
        {
            _cartServices = cartServices;
            _detailCartServices = detailCartServices;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_Cart data)
        {
            return Ok(await _cartServices.Create(data));
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(long Id, [FromQuery] DataRequest_Cart data)
        {
            return Ok(await _cartServices.Update(Id, data));
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            return Ok(await _cartServices.Delete(Id));
        }
        [HttpGet("GetAllCart")]
        public async Task<IActionResult> GetByAccount()
        {
            return Ok(await _cartServices.GetAllCart());
        }
        // Detail cart
        [HttpGet("Details/GetAccount")]
        [Authorize(RoleKeyString.User)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _detailCartServices.GetByAccount(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }
        [HttpPost("Details/Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_DetailCart dataRequest_DetailCart)
        {
            return Ok(await _detailCartServices.Create(dataRequest_DetailCart));
        }
        [HttpPost("Details/addCart")]
        [Authorize]
        public async Task<IActionResult> AddCard()
        {
            return Ok(await _detailCartServices.AddCart(dataRequest_DetailCart));
        }
        [HttpPut("Details/Update/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_DetailCart dataRequest_DetailCart)
        {
            return Ok(await _detailCartServices.Update(ID, dataRequest_DetailCart));
        }
        [HttpDelete("Details/Delete/{ID}")]
        public async Task<IActionResult> DetailDelete(long ID)
        {
            return Ok(await _detailCartServices.Delete(ID));
        }
    }
}
