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
using QLBH.Commons;

namespace QLBH.Business
{
    public class ImageCommentServices : IimageCommentServices<DataRespon_ImageComment, long>
    {
        private readonly IBaseRepository<Image_Comment> _imageRepository;

        private readonly UploadImages _uploadImages;
        public ImageCommentServices(IBaseRepository<Image_Comment> imageRepository, UploadImages uploadImages)
        {
            _imageRepository = imageRepository;
            _uploadImages = uploadImages;
        }

        public async Task Delete(long id)
        {
            try
            {
                var query = _imageRepository.GetQueryable(record => record.ID == id);
                _uploadImages.RemoveImage(query.Select(item => item.href).ToArray());
                await _imageRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
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

        public async Task Update(string UserName, long ID, RequestFiles files)
        {
            try
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }
        public async Task Create(string Username, long CommentID, List<IFormFile> files)
        {
            foreach (var file in files)
            {
                await _imageRepository.CreateAsync(new Image_Comment
                {
                    Comment_ProductID = CommentID,
<<<<<<< Updated upstream
                    href = await _uploadImages.UploadImage(Username, Common_Constants.CloudUpoad.FolderImage.Folder_Comment, file),
=======
                    href = await _uploadImages.UploadImage(Username,"", file),
>>>>>>> Stashed changes
                    Deleted = false,
                });
            }
        }
    }
}
