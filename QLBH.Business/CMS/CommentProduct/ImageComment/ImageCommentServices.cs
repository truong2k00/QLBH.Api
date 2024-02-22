using Microsoft.AspNetCore.Http;
using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.ImageHepper;
using System.ComponentModel.Design;

namespace QLBH.Business
{
    public class ImageCommentServices : IimageCommentServices<DataRespon_ImageComment, long>
    {
        private readonly IBaseRepository<Image_Comment> _imageRepository;

        private readonly UploadImages _uploadImages;
        public ImageCommentServices(IBaseRepository<Image_Comment> imageRepository,
            UploadImages uploadImages)
        {
            _imageRepository = imageRepository;
            _uploadImages = uploadImages;
        }

        public async Task<bool> Delete(long ID)
        {
            try
            {
                var data = await _imageRepository.GetByIDAsync(ID);
                data.Deleted = true;
                await _imageRepository.UpdateAsync(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<DataRespon_ImageComment> GetById(long id)
        {
            var data = await _imageRepository.GetByIDAsync(id);
            return new DataRespon_ImageComment
            {
                imageCommentID = data.ID,
                href = data.href,
                commentProductID = data.Comment_ProductID,
            };
        }

        public async Task<IEnumerable<DataRespon_ImageComment>> Update(string UserName, long ID, RequestFiles files)
        {
            var Data = await _imageRepository.GetAllAsync(record => record.Comment_ProductID == ID);
            if (Data.Any())
            {
                foreach (var item in Data)
                {
                    _uploadImages.RemoveImage(item.href);
                    await _imageRepository.DeleteAsync(item.ID);
                }
            }
            await Create(UserName, ID, files.files);
            var data = await _imageRepository.GetAllAsync(record => record.Comment_ProductID == ID);
            return data.Select(item => new DataRespon_ImageComment
            {
                imageCommentID = item.ID,
                commentProductID = item.Comment_ProductID,
                href = item.href
            });
        }
        public async Task Create(string Username, long CommentID, List<IFormFile> files)
        {
            foreach (var file in files)
            {
                await _imageRepository.CreateAsync(new Image_Comment
                {
                    Comment_ProductID = CommentID,
                    href = await _uploadImages.UploadImage(Username, file),
                    Deleted = false,
                });
            }
        }
    }
}
