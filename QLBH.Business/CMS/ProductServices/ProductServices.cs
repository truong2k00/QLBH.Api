using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using QLBH.Commons.Responces;
using QLBH.Commons.Common_Page;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
using clames = QLBH.Commons.Common_Constants.Clames;
using static QLBH.Commons.ImageHepper;
using System.Security.Policy;
using Microsoft.VisualStudio.Services.Identity;
using QLBH.Commons;
using Microsoft.VisualStudio.Services.Common;
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace QLBH.Business
{
    public class ProductServices : IProductServices<DataResponse_Product, int>
    {
        private readonly UploadImages _handleUpload;
        private readonly IBaseRepository<Product> _baseRepositoryProduct;
        private readonly IBaseRepository<Account> _baseRepositoryAccount;

        public ProductServices(UploadImages handleUpload
            , IBaseRepository<Product> baseRepositoryProduct
            , IBaseRepository<Account> baseRepositoryAccount)
        {
            _handleUpload = handleUpload;
            _baseRepositoryProduct = baseRepositoryProduct;
            _baseRepositoryAccount = baseRepositoryAccount;
        }
        public async Task Create(Request_Product item, RequestFiles files)
        {
            try
            {
                var username = (await _baseRepositoryAccount.GetAsync(record => record.ID == item.accountID)).User_Name;
                Product entity = new Product
                {
                    AccountID = item.accountID,
                    Product_Name = item.product_Name,
                    Product_Description = item.productDescription,
                    Meta_Product = Guid.NewGuid().ToString(),
                    ProductCatogoryID = item.categoryID,
                    Is_New = item.isNew,
                    Sale = item.sale,
                    Date_Delete = null,
                    Quantity = item.quantity,
                    Price = item.price,
                    Price_Sale = item.priceSale,
                    Evaluate = 5,
                    Deleted = false,
                    ImageProduct = await GenerateImageProduct(username, files.files)
                };
                await _baseRepositoryProduct.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }
        private static List<Respon_ImageProduct> imageURL(List<ImageProduct> images)
        {
            if (images == null) return null;
            var listimage = new List<Respon_ImageProduct>();
            foreach (var image in images)
            {
                listimage.Add(new Respon_ImageProduct
                {
                    imageUrl = image.Image_Url
                });
            }
            return listimage;
        }
        public async Task<List<ImageProduct>> GenerateImageProduct(string username, List<IFormFile> Files)
        {
            if (Files.Any()) return null;
            var productImages = new List<ImageProduct>();
            foreach (var file in Files)
            {
                productImages.Add(new ImageProduct
                {
                    Image_Url = await _handleUpload.UploadImage(username, Common_Constants.CloudUpoad.FolderImage.Folder_Product, file)
                });
            }
            return productImages;
        }
        public async Task Delete(long id)
        {
            try
            {
                var product = await _baseRepositoryProduct.GetAsync(record => record.ID == id);
                product.Deleted = true;
                await _baseRepositoryProduct.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }
        public async Task Update(long productID, Request_Product item, RequestFiles file)
        {
            try
            {
                var productEntity = await _baseRepositoryProduct.GetAsync(record => record.ID == productID);
                productEntity.Product_Name = item.product_Name;
                productEntity.Product_Description = item.productDescription;
                productEntity.Is_New = item.isNew;
                productEntity.Sale = item.sale;
                productEntity.Quantity = item.quantity;
                productEntity.Price = item.price;
                productEntity.Price_Sale = item.priceSale;
                await _baseRepositoryProduct.UpdateAsync(productEntity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }
        public IEnumerable<DataResponse_Product> GetByMeta(string meta)
        {
            var query = _baseRepositoryProduct.GetQueryable(record => record.Meta_Product == meta);
            var Data = query.Select(item => new DataResponse_Product
            {
                metaProduct = item.Meta_Product,
                productID = item.ID,
                categoryID = item.ProductCatogoryID,
                username = item.Account != null ? item.Account.User_Name : null,
                product_Name = item.Product_Name,
                productDescription = item.Product_Description,
                isNew = item.Is_New,
                quantity = item.Quantity,
                price = item.Price,
                sale = item.Sale,
                priceSale = item.Price_Sale,
                evaluate = item.Evaluate,
                imageProduct = imageURL(item.ImageProduct.ToList())
            }).AsEnumerable();
            return Data;
        }

        public PageResult<DataResponse_Product> GetAll(Pagination pagination, string keyWord, long accountID = 0, long categoryID = 0, bool sale = false)
        {
            var query = _baseRepositoryProduct.GetQueryable(record => record.Deleted == false);
            if (sale) query = query.Where(record => record.Sale == sale);
            if (accountID != 0) query = query.Where(record => record.AccountID == accountID);
            if (categoryID != 0) query = query.Where(record => record.ProductCatogoryID == categoryID);
            if (!keyWord.IsNullOrEmpty())
            {
                query = query.Where(record => record.ProductCatogory.CategoryName.ToLower().Contains(keyWord.ToLower())
                        || record.Product_Name.ToLower().Contains(keyWord.ToLower()));
            }
            var data = query.Select(item => new DataResponse_Product
            {
                metaProduct = item.Meta_Product,
                productID = item.ID,
                categoryID = item.ProductCatogoryID,
                username = item.Account != null ? item.Account.User_Name : null,
                product_Name = item.Product_Name,
                productDescription = item.Product_Description,
                isNew = item.Is_New,
                quantity = item.Quantity,
                price = item.Price,
                sale = item.Sale,
                priceSale = item.Price_Sale,
                evaluate = item.Evaluate,
                imageProduct = imageURL(item.ImageProduct.ToList())
            });
            pagination.TotalCount = query.Count();
            var result = PageResult<DataResponse_Product>.ToPageResult(pagination, data);
            return new PageResult<DataResponse_Product>(pagination, result);
        }
    }
}
