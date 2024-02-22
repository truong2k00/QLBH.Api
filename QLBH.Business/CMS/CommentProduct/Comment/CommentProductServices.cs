using Microsoft.AspNetCore.Http;
using QLBH.Commons;
using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Repository;
using QLBH.Commons.Responces;
using static QLBH.Commons.ImageHepper;
using QLBH.Commons.Common_Page;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Services.Users;

namespace QLBH.Business
{
    public class CommentProductServices : ICommentProduct<DataRequest_CommentProduct>
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly UploadImages _uploadImages;
        private readonly IBaseRepository<Comment_Product> _repositoryComment;
        private readonly IBaseRepository<Account> _repositoryAccount;
        private readonly ResponcesObject<DataRespon_CommentProduct> _dataRespon;

        public CommentProductServices(IHttpContextAccessor httpContext
            , UploadImages uploadImages
            , ResponcesObject<DataRespon_CommentProduct> dataRespon
            , IBaseRepository<Comment_Product> repositoryComment
            , IBaseRepository<Account> repositoryAccount)
        {
            _repositoryAccount = repositoryAccount;
            _dataRespon = dataRespon;
            _uploadImages = uploadImages;
            _httpContext = httpContext;
            _repositoryComment = repositoryComment;
        }

        public async Task Create(DataRequest_CommentProduct entity)
        {
            try
            {
                var comment = new Comment_Product
                {
                    Datetime_Comment = DateTime.Now,
                    Opinion = entity.opinion,
                    ProductID = entity.productID,
                    AccountID = entity.accountID
                };
                await _repositoryComment.CreateAsync(comment);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task CreateAsync(
            DataRequest_CommentProduct entity, RequestFiles Files)
        {
            var comment = new Comment_Product
            {
                Datetime_Comment = DateTime.Now,
                Opinion = entity.opinion,
                ProductID = entity.productID,
                AccountID = entity.accountID
            };
            Account account = await _repositoryAccount.GetByIDAsync(entity.accountID);
            comment.Image_Comment = await GenerateImageComment("Comment", Files.files);
            await _repositoryComment.CreateAsync(comment);
        }
        private async Task<List<Image_Comment>> GenerateImageComment(string name, List<IFormFile> files)
        {
            var ListImage = new List<Image_Comment>();
            foreach (var file in files)
            {
                ListImage.Add(new Image_Comment
                {
                    href = await _uploadImages.UploadImage(name, file),
                });
            }
            return ListImage;
        }
        public Task Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public async Task Update(long ID, DataRequest_CommentProduct item)
        {
            var comment = await _repositoryComment.GetAsync(record => record.ID == ID);
            comment.Opinion = item.opinion;
            await _repositoryComment.UpdateAsync(comment);
        }

        public PageResult<DataRespon_CommentProduct> GetAll(Pagination pagination, string KeyWord)
        {
            return GetAll(0, 0, pagination, KeyWord);
        }

        public Task<bool> DeleteAsync(long accountId, long id)
        {
            throw new NotImplementedException();
        }

        public PageResult<DataRespon_CommentProduct> GetAll(long productId = 0, Pagination pagination = null, string KeyWord = null)
        {
            return GetAll(productId, 0, pagination, KeyWord);
        }

        public PageResult<DataRespon_CommentProduct> GetAll(long productId, long accountId, Pagination pagination, string KeyWord)
        {
            var query = _repositoryComment.GetQueryable();
            if (productId > 0) query.Where(record => record.ProductID == productId);

            if (accountId > 0) query.Where(record => record.AccountID == accountId);

            if (KeyWord != null)
                query = query.Where(record => record.Product.Product_Name.ToLower().Contains(KeyWord.ToLower()));

            pagination.TotalCount = query.Count();
            var Data = query.Select(record => new DataRespon_CommentProduct
            {
                user = record.Account.User_Name,
                opinion = record.Opinion,
                datecreate = record.Datetime_Comment

            });
            var Result = PageResult<DataRespon_CommentProduct>.ToPageResult(pagination, Data);
            return new PageResult<DataRespon_CommentProduct>(pagination, Result);
        }
    }
}
