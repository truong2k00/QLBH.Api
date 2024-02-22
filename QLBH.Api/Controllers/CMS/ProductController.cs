using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Query.Internal;
using QLBH.Commons;
using QLBH.Commons.Common_Page;
using QLBH.Models;
using QLBH.Business;
using static QLBH.Commons.Common_Constants;
using QLBH.Api.Extensions;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices<DataResponse_Product, int> _productServices;
        private readonly IDetailProductServices _detailProductservices;
        private readonly IimageProducts<Respon_ImageProduct, long> _imageServices;
        public ProductController(IProductServices<DataResponse_Product, int> productServices, IDetailProductServices detailProductservices, IimageProducts<Respon_ImageProduct, long> imageServices)
        {
            _productServices = productServices;
            _detailProductservices = detailProductservices;
            _imageServices = imageServices;
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] Request_Product product, [FromForm] RequestFiles files)
        {
            var CreateAsync = await _productServices.Create(product, files);
            return Ok(CreateAsync);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] long ID, [FromBody] Request_Product product, [FromForm] RequestFiles Files)
        {
            return Ok(await _productServices.Update(ID, product, Files));
        }
        [HttpGet("GetAll-Product")]
        public IActionResult GetAll([FromQuery] Request_Pagination pagination, [FromQuery] string KeyWord)
        {
            return Ok(_productServices.GetAll(new Pagination
            {
                PageSize = pagination.PageSize,
                PageNumber = pagination.PageNumber
            }, KeyWord));
        }
        [HttpGet("GetAccountID/{AccountID}")]
        public IActionResult GetByIDAccount(long AccountID, [FromQuery] Request_Pagination pagination, [FromQuery] string KeyWord)
        {
            return Ok(_productServices.GetByAccount(new Pagination
            {
                PageSize = pagination.PageSize,
                PageNumber = pagination.PageNumber
            }, KeyWord, AccountID));
        }
        [HttpGet("GetCategoryID/{CategoryID}")]
        public IActionResult GetByIDCategory(long CategoryID, [FromQuery] Request_Pagination pagination, [FromQuery] string KeyWord)
        {
            return Ok(_productServices.GetByCategory(new Pagination
            {
                PageSize = pagination.PageSize,
                PageNumber = pagination.PageNumber
            }, KeyWord, CategoryID));
        }
        [HttpGet("GetAllSale")]
        public IActionResult GetAll()
        {
            return Ok(_productServices.GetAllSale());
        }
        [HttpGet("GetByMeta/{meta}")]
        public IActionResult GetByMeta(string meta)
        {
            return Ok(_productServices.GetByMeta(meta));
        }
        //Detail product
        [HttpPost("Detail/Create")]
        public async Task<IActionResult> Create([FromQuery] DataRequest_DetailProduct dataRequest_)
        {
            return Ok(await _detailProductservices.Create(dataRequest_));
        }
        [HttpPut("Detail/Update/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_DetailProduct dataRequest_)
        {
            return Ok(await _detailProductservices.Update(ID, dataRequest_));
        }
        [HttpDelete("Detail/Delete/{ID}")]
        public async Task<IActionResult> Delete(long ID)
        {
            return Ok(await _detailProductservices.Delete(ID));
        }
        //image product
        [HttpPost("Image/Create")]
        public async Task<IActionResult> Create([FromBody] Request_ImageProduct request_ImageProduct)
        {
            return Ok(await _imageServices.Create(request_ImageProduct));
        }
        [HttpGet("Image/GetAll")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Superuser)]
        public IActionResult ImageGetAll()
        {
            return Ok(_imageServices.GetAllAsync());
        }
        [HttpGet("Image/GetAll/{ProductID}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Superuser)]
        public IActionResult GetAllAsync(long productID)
        {
            return Ok(_imageServices.GetAllAsync(productID));
        }
    }
}
