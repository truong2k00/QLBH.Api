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
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace QLBH.Business
{
    public class ProductServices : IProductServices<DataResponse_Product, int>
    {
        private readonly UploadImages _handleUpload;
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBaseRepository<Product> _baseRepositoryProduct;
        private readonly IBaseRepository<Account> _baseRepositoryAccount;
        private readonly IBaseRepository<ProductCategory> _baseRepositoryCategory;

        public ProductServices(IBaseRepository<Account> baseRepositoryAccount
            , UploadImages handleUpload
            , IHttpContextAccessor httpContextAccessor
            , AppDbContext appDbContext
            , IBaseRepository<Product> baseRepositoryProduct
            , IBaseRepository<ProductCategory> baseRepositoryCategory)
        {
            _handleUpload = handleUpload;
            _httpContextAccessor = httpContextAccessor;
            _appDbContext = appDbContext;
            _baseRepositoryProduct = baseRepositoryProduct;
            _baseRepositoryCategory = baseRepositoryCategory;
            _baseRepositoryAccount = baseRepositoryAccount;
        }
        public async Task<DataResponse_Product> Create(Request_Product item, RequestFiles files)
        {
            var account = await _baseRepositoryAccount.GetAsync(record => record.ID ==
                long.Parse(_httpContextAccessor.HttpContext.User.FindFirst(clames.ID).Value));
            var product = new List<Product>();
            Product entity = new Product
            {
                Product_Name = item.Product_Name,
                Product_Description = item.Product_Description,
                Meta_Product = Guid.NewGuid().ToString(),
                ProductCatogory = await _baseRepositoryCategory.GetAsync(x => x.ID == item.Category_ID),
                Is_New = item.Is_New,
                Sale = item.Sale,
                Date_Delete = null,
                Quantity = item.Quantity,
                Price = item.Price,
                Price_Sale = item.Price_Sale,
                Evaluate = 5,
                Deleted = false,
                ImageProduct = await GenerateImageProduct(files.Files)
            };
            product.Add(entity);
            account.Product = product;
            await _baseRepositoryAccount.UpdateAsync(account);
            return new DataResponse_Product
            {
                Meta_Product = entity.Meta_Product,
                Product_ID = entity.ID,
                Username = account.User_Name,
                Product_Name = entity.Product_Name,
                Product_Description = entity.Product_Description,
                Is_New = entity.Is_New,
                Quantity = entity.Quantity,
                Price = entity.Price,
                Sale = entity.Sale,
                Price_Sale = entity.Price_Sale,
                Evaluate = entity.Evaluate,
                ImageProduct = imageURL(entity.ImageProduct.ToList())
            };
        }
        private static List<Respon_ImageProduct> imageURL(List<ImageProduct> images)
        {
            if (images == null) return null;
            var listimage = new List<Respon_ImageProduct>();
            foreach (var image in images)
            {
                listimage.Add(new Respon_ImageProduct
                {
                    Image_Url = image.Image_Url
                });
            }
            return listimage;
        }
        public async Task<List<ImageProduct>> GenerateImageProduct(List<IFormFile> Files)
        {
            if (Files == null) return null;
            var productImages = new List<ImageProduct>();
            foreach (var file in Files)
            {
                productImages.Add(new ImageProduct
                {
                    Image_Url = await _handleUpload.UploadImage(_httpContextAccessor.HttpContext.User.FindFirst(clames.USER).Value, file)
                });
            }
            return productImages;
        }
        public async Task<bool> Delete(long ID)
        {
            var product = await _appDbContext.Product.FirstOrDefaultAsync(x => x.ID == ID);
            product.Deleted = true;
            await _baseRepositoryProduct.UpdateAsync(product);
            return true;
        }
        public async Task<DataResponse_Product> Update(long IDProduct, Request_Product item, RequestFiles file)
        {
            var productEntity = await _baseRepositoryProduct.GetAsync(x => x.ID == IDProduct);
            if (productEntity != null)
            {
                return null;
            }
            else
            {
                productEntity.Deleted = true;
                productEntity.Date_Delete = DateTime.Now;
                await _baseRepositoryProduct.UpdateAsync(productEntity);
                return await Create(item, file);
            }
        }

        public Task<DataResponse_Product> GetByID(int ID)
        {
            throw new Exception();
        }

        public PageResult<DataResponse_Product> GetAll(Pagination pagination, string KeyWord)
        {
            var query = _baseRepositoryProduct.GetQueryable(record => record.Deleted == false);
            if (!KeyWord.IsNullOrEmpty())
            {
                query = query.Where(record => record.ProductCatogory.CategoryName.ToLower().Contains(KeyWord.ToLower())
                        || record.Product_Name.ToLower().Contains(KeyWord.ToLower()));
            }
            var data = query.Select(item => new DataResponse_Product
            {
                Meta_Product = item.Meta_Product,
                Product_ID = item.ID,
                Category_ID = item.ProductCatogoryID,
                Username = item.Account != null ? item.Account.User_Name : null,
                Product_Name = item.Product_Name,
                Product_Description = item.Product_Description,
                Is_New = item.Is_New,
                Quantity = item.Quantity,
                Price = item.Price,
                Sale = item.Sale,
                Price_Sale = item.Price_Sale,
                Evaluate = item.Evaluate,
                ImageProduct = imageURL(item.ImageProduct.ToList())
            });
            pagination.TotalCount = query.Count();
            var result = PageResult<DataResponse_Product>.ToPageResult(pagination, data);
            return new PageResult<DataResponse_Product>(pagination, result);
        }

        public IEnumerable<DataResponse_Product> GetAllSale()
        {
            var query = _baseRepositoryProduct.GetQueryable(record => record.Deleted == false);
            query = query.Where(record => record.Sale == true);
            var Data = query.Select(x => new DataResponse_Product
            {
                Meta_Product = x.Meta_Product,
                Product_ID = x.ID,
                Username = x.Account != null ? x.Account.User_Name : null,
                Product_Name = x.Product_Name,
                Product_Description = x.Product_Description,
                Is_New = x.Is_New,
                Quantity = x.Quantity,
                Price = x.Price,
                Sale = x.Sale,
                Price_Sale = x.Price_Sale,
                Evaluate = x.Evaluate,
                ImageProduct = imageURL(x.ImageProduct.ToList())
            }).AsEnumerable();
            return Data;
        }
        public IEnumerable<DataResponse_Product> GetByMeta(string meta)
        {
            var query = _baseRepositoryProduct.GetQueryable(record => record.Meta_Product == meta);
            var Data = query.Select(item => new DataResponse_Product
            {
                Meta_Product = item.Meta_Product,
                Product_ID = item.ID,
                Category_ID = item.ProductCatogoryID,
                Username = item.Account != null ? item.Account.User_Name : null,
                Product_Name = item.Product_Name,
                Product_Description = item.Product_Description,
                Is_New = item.Is_New,
                Quantity = item.Quantity,
                Price = item.Price,
                Sale = item.Sale,
                Price_Sale = item.Price_Sale,
                Evaluate = item.Evaluate,
                ImageProduct = imageURL(item.ImageProduct.ToList())
            }).AsEnumerable();
            return Data;
        }

        public PageResult<DataResponse_Product> GetByAccount(Pagination pagination, string KeyWord, long IDAccount)
        {
            var query = _baseRepositoryProduct.GetQueryable(record => record.AccountID == IDAccount && record.Deleted == false);
            if (!KeyWord.IsNullOrEmpty())
            {
                query = query.Where(record => record.ProductCatogory.CategoryName.ToLower().Contains(KeyWord.ToLower())
                        || record.Product_Name.ToLower().Contains(KeyWord.ToLower()));
            }
            var data = query.Select(item => new DataResponse_Product
            {
                Meta_Product = item.Meta_Product,
                Product_ID = item.ID,
                Category_ID = item.ProductCatogoryID,
                Username = item.Account != null ? item.Account.User_Name : null,
                Product_Name = item.Product_Name,
                Product_Description = item.Product_Description,
                Is_New = item.Is_New,
                Quantity = item.Quantity,
                Price = item.Price,
                Sale = item.Sale,
                Price_Sale = item.Price_Sale,
                Evaluate = item.Evaluate,
                ImageProduct = imageURL(item.ImageProduct.ToList())
            });
            pagination.TotalCount = query.Count();
            var result = PageResult<DataResponse_Product>.ToPageResult(pagination, data);
            return new PageResult<DataResponse_Product>(pagination, result);
        }

        public PageResult<DataResponse_Product> GetByCategory(Pagination pagination, string KeyWord, long IDCategory)
        {
            var query = _baseRepositoryProduct.GetQueryable(record => record.ProductCatogoryID == IDCategory && record.Deleted == false);
            if (!KeyWord.IsNullOrEmpty())
            {
                query = query.Where(record => record.ProductCatogory.CategoryName.ToLower().Contains(KeyWord.ToLower())
                        || record.Product_Name.ToLower().Contains(KeyWord.ToLower()));
            }
            var data = query.Select(item => new DataResponse_Product
            {
                Meta_Product = item.Meta_Product,
                Product_ID = item.ID,
                Category_ID = item.ProductCatogoryID,
                Username = item.Account != null ? item.Account.User_Name : null,
                Product_Name = item.Product_Name,
                Product_Description = item.Product_Description,
                Is_New = item.Is_New,
                Quantity = item.Quantity,
                Price = item.Price,
                Sale = item.Sale,
                Price_Sale = item.Price_Sale,
                Evaluate = item.Evaluate,
                ImageProduct = imageURL(item.ImageProduct.ToList())
            });
            pagination.TotalCount = query.Count();
            var result = PageResult<DataResponse_Product>.ToPageResult(pagination, data);
            return new PageResult<DataResponse_Product>(pagination, result);
        }
    }
}
