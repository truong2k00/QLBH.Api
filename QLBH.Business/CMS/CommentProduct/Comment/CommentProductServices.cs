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
        private readonly UploadImages _uploadImages;
        private readonly IBaseRepository<Comment_Product> _repositoryComment;

        public CommentProductServices(UploadImages uploadImages, IBaseRepository<Comment_Product> repositoryComment)
        {
            _uploadImages = uploadImages;
            _repositoryComment = repositoryComment;
        }

        public async Task Create(DataRequest_CommentProduct entity)
        {
            await Create(entity, null);
        }

        public async Task Create(DataRequest_CommentProduct entity, RequestFiles files)
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
                if (files.files.Any())
                {
                    comment.Image_Comment = await GenerateImageComment("Comment", files.files);
                }
                await _repositoryComment.CreateAsync(comment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }
        private async Task<List<Image_Comment>> GenerateImageComment(string name, List<IFormFile> files)
        {
            var ListImage = new List<Image_Comment>();
            foreach (var file in files)
            {
                ListImage.Add(new Image_Comment
                {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                    href = await _uploadImages.UploadImage(name,Common_Constants.CloudUpoad.FolderImage.Folder_Comment, file),
=======
                    href = await _uploadImages.UploadImage(name,"", file),
>>>>>>> Stashed changes
=======
                    href = await _uploadImages.UploadImage(name,Common_Constants.CloudUpoad.FolderImage.Folder_Comment, file),
>>>>>>> Stashed changes
                });
            }
            return ListImage;
        }

        public async Task Update(long ID, DataRequest_CommentProduct item)
        {
            try
            {
                var comment = await _repositoryComment.GetAsync(record => record.ID == ID);
                comment.Opinion = item.opinion;
                await _repositoryComment.UpdateAsync(comment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }
        public async Task Delete(long id)
        {
            await _repositoryComment.DeleteAsync(id);
        }
        public async Task Delete(long accountId, long id)
        {
            try
            {
                var query = _repositoryComment.GetQueryable(record => record.ID == id);
                if (accountId != 0)
                {
                    query = query.Where(record => record.AccountID == accountId);
                }
                if (query.Any())
                {
                    foreach (var item in query)
                    {
                        _uploadImages.RemoveImage(item.Image_Comment.Select(record => record.href).ToArray());
                        await _repositoryComment.DeleteAsync(item.ID);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }
        public PageResult<DataRespon_CommentProduct> GetAll(Pagination pagination,long accountId = 0, long productId = 0, string KeyWord = null)
        {
            var query = _repositoryComment.GetQueryable();
            if (productId != 0) query = query.Where(record => record.ProductID == productId);

            if (accountId != 0) query = query.Where(record => record.AccountID == accountId);

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
