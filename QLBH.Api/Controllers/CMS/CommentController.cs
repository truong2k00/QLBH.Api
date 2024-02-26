using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.Tokens;
using QLBH.Api.Extensions;
using QLBH.Business;
using QLBH.Commons.Common_Page;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentProduct<DataRequest_CommentProduct> _commentServices;
        private readonly IimageCommentServices<DataRespon_ImageComment, long> _imageCommentServices;

        public CommentController(ICommentProduct<DataRequest_CommentProduct> commentServices
            , IimageCommentServices<DataRespon_ImageComment, long> imagecommentServices)
        {
            _commentServices = commentServices;
            _imageCommentServices = imagecommentServices;
        }
        [HttpPost("Create")]
        public async Task Create([FromForm] DataRequest_CommentProduct comment
            , [FromForm] RequestFiles files)
        {
            comment.accountID = Convert.ToInt64(HttpContext.User.FindFirst(Clames.ID).Value);
            await _commentServices.Create(comment, files.files.Any() ? files : null);
        }
        [HttpPut("Upadte/{ID}")]
        public async Task Update(long ID, [FromQuery] DataRequest_CommentProduct dataRequest_CommentProduct)
        {
            await _commentServices.Update(ID, dataRequest_CommentProduct);
        }
        [HttpDelete("Delete/{ID}")]
        [Authorize(RoleKeyString.Editor)]
        public async Task Delete(long ID)
        {
            await _commentServices.Delete(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value), ID);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] Request_Pagination request_Pagination, [FromQuery] long accountid, long productid, [FromQuery] string keyWord)
        {
            return Ok(_commentServices.GetAll(new Pagination
            {
                PageNumber = request_Pagination.pageNumber,
                PageSize = request_Pagination.pageSize
            }, accountid, productid, keyWord));
        }
        //image comment
        [HttpPut("UpdateImage/{IDComment}")]
        public async Task updateImage(long commentID, [FromForm] RequestFiles Files)
        {
            var username = HttpContext.User.FindFirst(Clames.USER).Value;
            await _imageCommentServices.Update(username, commentID, Files);
        }
        [HttpDelete("DeleteImage/{imageID}")]
        public async Task DeleteImage(long imageID)
        {
            await _imageCommentServices.Delete(imageID);
        }
        [HttpGet("GetImage/{imageID}")]
        public async Task<IActionResult> GetImage(long imageID)
        {
            return Ok(await _imageCommentServices.GetById(imageID));
        }
    }
}
