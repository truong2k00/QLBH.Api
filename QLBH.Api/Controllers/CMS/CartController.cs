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
    [Route(DEFAULT_CONTROLER_RAUTER)]
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
        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(_cartServices.GetAllCart());
        }
        // Detail cart
        [HttpGet()]
        [Authorize(RoleKeyString.User)]
        public IActionResult GetAllDetail()
        {
            return Ok(_detailCartServices.GetByAccount(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }
        [HttpPost()]
        public async Task<IActionResult> CreateDetail([FromQuery] DataRequest_DetailCart dataRequest_DetailCart)
        {
            await _detailCartServices.Create(dataRequest_DetailCart);
            return Ok();
        }
        [HttpPost("{meta}")]
        [Authorize]
        public async Task<IActionResult> AddCard(string meta)
        {
            await _detailCartServices.AddCart(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value), meta);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDetails(long id, [FromQuery] DataRequest_DetailCart dataRequest_DetailCart)
        {
            await _detailCartServices.Update(id, dataRequest_DetailCart);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _detailCartServices.Delete(id);
            return Ok();
        }
    }
}
