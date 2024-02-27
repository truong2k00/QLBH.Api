using Microsoft.AspNetCore.Http;
using QLBH.Commons;
using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Repository;
using static QLBH.Commons.ImageHepper;
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
using clames = QLBH.Commons.Common_Constants.Clames;
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace QLBH.Business
{
    public class ImageProductServices : IimageProducts<Respon_ImageProduct, long>
    {
        private readonly IBaseRepository<ImageProduct> _baseRepositoryImgProduct;
        private readonly UploadImages _uploadImage;
        private readonly IBaseRepository<Product> _baseRepositoryProduct;

        public ImageProductServices(IBaseRepository<Product> baseRepositoryProduct
            , IBaseRepository<ImageProduct> baseRepositoryImgProduct
            , UploadImages uploadImage)
        {
            _uploadImage = uploadImage;
            _baseRepositoryProduct = baseRepositoryProduct;
            _baseRepositoryImgProduct = baseRepositoryImgProduct;
        }

        public async Task Create(Request_ImageProduct item)
        {
            try
            {
                var username = _baseRepositoryProduct.GetQueryable(record => record.ID == item.product_ID && record.Account.ID == item.accountID).Select(record => record.Account.User_Name).FirstOrDefault();
                ImageProduct image = new ImageProduct
                {
                    Image_Url = await _uploadImage.UploadImage(username, Common_Constants.CloudUpoad.FolderImage.Folder_Product, item.file),
                    Product = await _baseRepositoryProduct.GetByIDAsync(item.product_ID)
                };
                await _baseRepositoryImgProduct.CreateAsync(image);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }
        public async Task Update(long id, Request_ImageProduct item)
        {
            try
            {
                var query = _baseRepositoryImgProduct.GetQueryable(record => record.ID == id && record.Product.AccountID == item.accountID);
                var username = query.Where(record => record.Product.AccountID == item.accountID).Select(record => record.Product.Account.User_Name).FirstOrDefault();
                _uploadImage.RemoveImage(query.FirstOrDefault().Image_Url);
                query.FirstOrDefault().Image_Url = await _uploadImage.UploadImage(username, Common_Constants.CloudUpoad.FolderImage.Folder_Product, item.file);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                var entity = await _baseRepositoryImgProduct.GetAsync(record => record.ID == id);
                _uploadImage.RemoveImage(entity.Image_Url);
                await _baseRepositoryImgProduct.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }

        public IEnumerable<Respon_ImageProduct> GetAllAsync(long productID)
        {
            var query = _baseRepositoryImgProduct.GetQueryable();
            if (productID > 0)
            {
                query = query.Where(record => record.Product.ID == productID);
            }
            var data = query.Select(record => new Respon_ImageProduct
            {
                imageUrl = record.Image_Url
            });
            return data;
        }

        public IEnumerable<Respon_ImageProduct> GetAllAsync()
        {
            return GetAllAsync(0);
        }

        public async Task<Respon_ImageProduct> GetByIDAsync(long ID)
        {
            var imagep = await _baseRepositoryImgProduct.GetAsync(record => record.ID == ID);
            return new Respon_ImageProduct
            {
                imageUrl = imagep.Image_Url
            };
        }
    }
}
