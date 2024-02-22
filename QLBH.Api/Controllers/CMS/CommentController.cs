using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.Tokens;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create([FromForm] DataRequest_CommentProduct comment
            , [FromForm] RequestFiles Files)
        {
            comment.accountID = Convert.ToInt64(HttpContext.User.FindFirst(Clames.ID).Value);
            await _commentServices.CreateAsync(comment, Files);
            return Ok();
        }
        [HttpPut("Upadte/{ID}")]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_CommentProduct dataRequest_CommentProduct)
        {
            await _commentServices.Update(ID, dataRequest_CommentProduct);
            return Ok();
        }
        [HttpDelete("Delete/{ID}")]
        public async Task<IActionResult> Delete(long ID)
        {
            await _commentServices.Delete(ID);
            return Ok();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] Request_Pagination request_Pagination, [FromQuery] string KeyWord = null)
        {
            return Ok(_commentServices.GetAll(new Pagination
            {
                PageNumber = request_Pagination.pageNumber,
                PageSize = request_Pagination.pageSize
            }, KeyWord));
        }
        //image comment
        [HttpPut("UpdateImage/{IDComment}")]
        public async Task<IActionResult> updateImage(long IDComment, [FromForm] RequestFiles Files)
        {
            var username = HttpContext.User.FindFirst(Clames.USER).Value;
            return Ok(await _imageCommentServices.Update(username, IDComment, Files));
        }
        [HttpDelete("DeleteImage/{IDImage}")]
        public async Task<IActionResult> DeleteImage(long IDImage)
        {
            return Ok(await _imageCommentServices.Delete(IDImage));
        }
        [HttpGet("GetImage/{IDImage}")]
        public async Task<IActionResult> GetImage(long IDImage)
        {
            return Ok(await _imageCommentServices.GetById(IDImage));
        }
    }
}
