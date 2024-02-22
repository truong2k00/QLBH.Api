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
        private readonly IHttpContextAccessor _httpContext;

        public ImageProductServices(IBaseRepository<Product> baseRepositoryProduct
            , IBaseRepository<ImageProduct> baseRepositoryImgProduct
            , UploadImages uploadImage
            , IHttpContextAccessor httpContext)
        {
            _uploadImage = uploadImage;
            _httpContext = httpContext;
            _baseRepositoryProduct = baseRepositoryProduct;
            _baseRepositoryImgProduct = baseRepositoryImgProduct;
        }

        public async Task<Respon_ImageProduct> Create(Request_ImageProduct item)
        {
            ImageProduct image = new ImageProduct
            {
                Image_Url = await _uploadImage.UploadImage(_httpContext.HttpContext.User.FindFirst("User").Value, item.file),
                Product = await _baseRepositoryProduct.GetByIDAsync(item.Product_ID)
            };
            await _baseRepositoryImgProduct.CreateAsync(image);
            return new Respon_ImageProduct
            {
                Image_Url = image.Image_Url
            };
        }

        public async Task<bool> Delete(long ID)
        {
            return await _baseRepositoryImgProduct.DeleteAsync(ID);
        }

        public async Task<IEnumerable<Respon_ImageProduct>> GetAllAsync(long IDProduct)
        {
            var lisimageproduct = await _baseRepositoryImgProduct.GetAllAsync(x => x.Product.ID == IDProduct);
            var lisimage = lisimageproduct.Select(record => new Respon_ImageProduct
            {
                Image_Url = record.Image_Url
            });
            return lisimage;
        }

        public async Task<IEnumerable<Respon_ImageProduct>> GetAllAsync()
        {
            var lisimageproduct = await _baseRepositoryImgProduct.GetAllAsync();
            var lisimage = lisimageproduct.Select(record => new Respon_ImageProduct
            {
                Image_Url = record.Image_Url
            });
            return lisimage;
        }

        public async Task<Respon_ImageProduct> GetByIDAsync(long ID)
        {
            var imagep = await _baseRepositoryImgProduct.GetAsync(record => record.ID == ID);
            return new Respon_ImageProduct
            {
                Image_Url = imagep.Image_Url
            };
        }

        public async Task<Respon_ImageProduct> Update(long ID, Request_ImageProduct item)
        {
            var entityimage = await _baseRepositoryImgProduct.GetByIDAsync(ID);
            var entity = new ImageProduct
            {
                Image_Url = await _uploadImage.UploadImage(
                    _httpContext.HttpContext.User.FindFirst(clames.USER).Value, item.file),
                Product = await _baseRepositoryProduct.GetByIDAsync(item.Product_ID)
            };
            await _baseRepositoryImgProduct.DeleteAsync(ID);
            await _baseRepositoryImgProduct.CreateAsync(entity);
            return new Respon_ImageProduct
            {
                Image_Url = entityimage.Image_Url
            };
        }
    }
}
