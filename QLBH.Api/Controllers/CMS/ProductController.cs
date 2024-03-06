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
using System.Security.Permissions;

namespace QLBH.Api.Controllers
{
    [Route(DEFAULT_CONTROLER_RAUTER)]
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
        public async Task Create([FromForm] Request_Product product, [FromForm] RequestFiles files)
        {
            await _productServices.Create(product, files);
        }
        [HttpPut("Update")]
        public async Task Update([FromQuery] long ID, [FromBody] Request_Product product, [FromForm] RequestFiles Files)
        {
            await _productServices.Update(ID, product, Files);
        }
        [HttpGet()]
        public IActionResult GetAll([FromQuery] Request_Pagination pagination, [FromQuery] string keyWord, [FromQuery] long accountID = 0, [FromQuery] List<long> categoryIDs = null, [FromQuery] bool sale = false)
        {
            return Ok(_productServices.GetAll(new Pagination
            {
                PageNumber = pagination.pageNumber,
                PageSize = pagination.pageSize
            }, keyWord, accountID, categoryIDs, sale));
        }
        [HttpGet()]
        public IActionResult GetAlls([FromQuery] List<long> categoryIDs, [FromQuery] string keyWord, [FromQuery] long accountID = 0,  [FromQuery] bool sale = false)
        {
            return Ok(_productServices.GetAll(keyWord, accountID, categoryIDs, sale));
        }
        [HttpGet()]
        [Authorize(RoleKeyString.Superuser, RoleKeyString.Editor, RoleKeyString.Guest, RoleKeyString.Manager)]
        public IActionResult GetByAll([FromQuery] Request_Pagination pagination, [FromQuery] string keyWord, [FromQuery] List<long> categoryIDs = null, bool sale = false)
        {
            long accountID = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            return Ok(_productServices.GetAll(new Pagination
            {
                PageNumber = pagination.pageNumber,
                PageSize = pagination.pageSize
            }, keyWord, accountID, categoryIDs, sale));
        }
        [HttpGet("GetByMeta/{meta}")]
        public IActionResult GetByMeta(string meta)
        {
            return Ok(_productServices.GetByMeta(meta));
        }
        //Detail product
        [HttpPost("Detail/Create")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Moderator, RoleKeyString.Manager, RoleKeyString.Editor)]
        public async Task Create([FromQuery] DataRequest_DetailProduct dataRequest_)
        {
            await _detailProductservices.Create(dataRequest_);
        }
        [HttpPut("Detail/Update/{iD}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Moderator, RoleKeyString.Manager, RoleKeyString.Editor)]
        public async Task Update(long iD, [FromQuery] DataRequest_DetailProduct dataRequest_)
        {
            await _detailProductservices.Update(iD, dataRequest_);
        }
        [HttpDelete("Detail/Delete/{iD}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Moderator, RoleKeyString.Manager, RoleKeyString.Editor)]
        public async Task Delete(long iD)
        {
            await _detailProductservices.Delete(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value), iD);
        }
        //image product
        [HttpPost("Image/Create")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Moderator, RoleKeyString.Manager, RoleKeyString.Editor)]
        public async Task Create([FromBody] Request_ImageProduct request_ImageProduct)
        {
            request_ImageProduct.accountID = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            await _imageServices.Create(request_ImageProduct);
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
