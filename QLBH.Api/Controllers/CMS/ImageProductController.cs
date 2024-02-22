using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;
using QLBH.Api.Extensions;
using QLBH.Business;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    [Authorize]
    public class ImageProductController : ControllerBase
    {
        private readonly IimageProducts<Respon_ImageProduct, long> _iimageProducts;

        public ImageProductController(IimageProducts<Respon_ImageProduct, long> iimageProducts)
        {
            _iimageProducts = iimageProducts;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Request_ImageProduct request_ImageProduct)
        {
            return Ok(await _iimageProducts.Create(request_ImageProduct));
        }
        [HttpGet("GetAll")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Superuser)]
        public IActionResult GetAll()
        {
            return Ok(_iimageProducts.GetAllAsync());
        }
        [HttpGet("GetAll/{ProductID}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Superuser)]
        public IActionResult GetAllAsync(long productID)
        {
            return Ok(_iimageProducts.GetAllAsync(productID));
        }
    }
}
