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
            try
            {
                await _cartServices.Create(data);
                return Ok(SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(long Id, [FromQuery] DataRequest_Cart data)
        {
            try
            {
                await _cartServices.Update(Id, data);
                return Ok(SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            try
            {
                await _cartServices.Delete(Id);
                return Ok(SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        public async Task Create([FromQuery] DataRequest_DetailCart dataRequest_DetailCart)
        {
            try
            {
                await _detailCartServices.Create(dataRequest_DetailCart);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("Details/addCart/{meta}")]
        [Authorize]
        public async Task<IActionResult> AddCard(string meta)
        {
            try
            {
                await _detailCartServices.AddCart(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value), meta);
                return Ok(SUCCESS);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Details/Update/{ID}")]
        public async Task Update(long ID, [FromQuery] DataRequest_DetailCart dataRequest_DetailCart)
        {
            await _detailCartServices.Update(ID, dataRequest_DetailCart);
        }
        [HttpDelete("Details/Delete/{ID}")]
        public async Task DetailDelete(long ID)
        {
            await _detailCartServices.Delete(ID);
        }
    }
}
