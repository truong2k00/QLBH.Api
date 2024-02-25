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

        public async Task Create(Request_ImageProduct item)
        {
            ImageProduct image = new ImageProduct
            {
                Image_Url = await _uploadImage.UploadImage(_httpContext.HttpContext.User.FindFirst("User").Value, Common_Constants.CloudUpoad.FolderImage.Folder_Product, item.file),
                Product = await _baseRepositoryProduct.GetByIDAsync(item.product_ID)
            };
            await _baseRepositoryImgProduct.CreateAsync(image);
        }

        public async Task Delete(long ID)
        {
            await _baseRepositoryImgProduct.DeleteAsync(ID);
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

        public async Task Update(long ID, Request_ImageProduct item)
        {
            var entityimage = await _baseRepositoryImgProduct.GetByIDAsync(ID);
            var entity = new ImageProduct
            {
                Image_Url = await _uploadImage.UploadImage(
                    _httpContext.HttpContext.User.FindFirst(clames.USER).Value, Common_Constants.CloudUpoad.FolderImage.Folder_Product, item.file),
                Product = await _baseRepositoryProduct.GetByIDAsync(item.product_ID)
            };
            await _baseRepositoryImgProduct.DeleteAsync(ID);
            await _baseRepositoryImgProduct.CreateAsync(entity);
        }
    }
}
