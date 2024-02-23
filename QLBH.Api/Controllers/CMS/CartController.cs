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
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
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
        [HttpPut("Update/{id}")]
        public async Task Update(long id, [FromQuery] DataRequest_Cart data)
        {
            await _cartServices.Update(id, data);
        }
        [HttpDelete("Delete/{id}")]
        public async Task Delete(long id)
        {
            await _cartServices.Delete(id);
        }
        [HttpPost("Create")]
        public async Task Create([FromQuery] DataRequest_Cart data)
        {
            await _cartServices.Create(data);
        }
        [HttpGet("GetAllCart")]
        public IActionResult GetByAccount()
        {
            return Ok(_cartServices.GetAllCart());
        }
        // Detail cart
        [HttpGet("Details/GetAccount")]
        [Authorize(RoleKeyString.User)]
        public IActionResult GetAll()
        {
            return Ok(_detailCartServices.GetByAccount(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }
        [HttpPost("Details/Create")]
        public async Task Create([FromQuery] DataRequest_DetailCart dataRequest_DetailCart)
        {
            await _detailCartServices.Create(dataRequest_DetailCart);
        }
        [HttpPost("Details/addCart/{meta}")]
        [Authorize]
        public async Task AddCard(string meta)
        {
            await _detailCartServices.AddCart(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value), meta);
        }
        [HttpPut("Details/Update/{id}")]
        public async Task Update(long id, [FromQuery] DataRequest_DetailCart dataRequest_DetailCart)
        {
            await _detailCartServices.Update(id, dataRequest_DetailCart);
        }
        [HttpDelete("Details/Delete/{ID}")]
        public async Task DetailDelete(long ID)
        {
            await _detailCartServices.Delete(ID);
        }
    }
}
