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
    //
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
            await _productServices.Create(product, files);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] long ID, [FromBody] Request_Product product, [FromForm] RequestFiles Files)
        {
            await _productServices.Update(ID, product, Files);
            return Ok();
        }
        [HttpGet("GetAll-Product")]
        public IActionResult GetAll([FromQuery] Request_Pagination pagination, [FromQuery] string keyWord)
        {
            return Ok(_productServices.GetAll(new Pagination
            {
                PageNumber = pagination.pageNumber,
                PageSize = pagination.pageSize
            }, keyWord));
        }
        [HttpGet("GetAccountID/{accountID}")]
        public IActionResult GetByIDAccount(long accountID, [FromQuery] Request_Pagination pagination, [FromQuery] string keyWord)
        {
            return Ok(_productServices.GetByAccount(new Pagination
            {
                PageSize = pagination.pageSize,
                PageNumber = pagination.pageNumber
            }, keyWord, accountID));
        }
        [HttpGet("GetCategoryID/{CategoryID}")]
        public IActionResult GetByIDCategory(long CategoryID, [FromQuery] Request_Pagination pagination, [FromQuery] string keyWord)
        {
            return Ok(_productServices.GetByCategory(new Pagination
            {
                PageSize = pagination.pageSize,
                PageNumber = pagination.pageNumber
            }, keyWord, CategoryID));
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
            await _detailProductservices.Create(dataRequest_);
            return Ok();
        }
        [HttpPut("Detail/Update/{iD}")]
        public async Task<IActionResult> Update(long iD, [FromQuery] DataRequest_DetailProduct dataRequest_)
        {
            await _detailProductservices.Update(iD, dataRequest_);
            return Ok();
        }
        [HttpDelete("Detail/Delete/{iD}")]
        public async Task<IActionResult> Delete(long iD)
        {
            await _detailProductservices.Delete(iD);
            return Ok();
        }
        //image product
        [HttpPost("Image/Create")]
        public async Task<IActionResult> Create([FromBody] Request_ImageProduct request_ImageProduct)
        {
            await _imageServices.Create(request_ImageProduct);
            return Ok();
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
