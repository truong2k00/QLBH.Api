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
        public async Task Create(Request_Product item, RequestFiles files)
        {
            var account = await _baseRepositoryAccount.GetAsync(record => record.ID ==
                long.Parse(_httpContextAccessor.HttpContext.User.FindFirst(clames.ID).Value));
            var product = new List<Product>();
            Product entity = new Product
            {
                Product_Name = item.product_Name,
                Product_Description = item.productDescription,
                Meta_Product = Guid.NewGuid().ToString(),
                ProductCatogory = await _baseRepositoryCategory.GetAsync(x => x.ID == item.categoryID),
                Is_New = item.isNew,
                Sale = item.sale,
                Date_Delete = null,
                Is_Deleted = false,
                Quantity = item.quantity,
                Price = item.price,
                Price_Sale = item.priceSale,
                Evaluate = 5,
                Deleted = false,
                ImageProduct = await GenerateImageProduct(files.files)
            };
            product.Add(entity);
            account.Product = product;
            await _baseRepositoryAccount.UpdateAsync(account);
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
        public async Task Delete(long ID)
        {
            var product = await _appDbContext.Product.FirstOrDefaultAsync(x => x.ID == ID);
            product.Deleted = true;
            await _baseRepositoryProduct.UpdateAsync(product);
        }
        public async Task Update(long IDProduct, Request_Product item, RequestFiles file)
        {
            var productEntity = await _baseRepositoryProduct.GetAsync(x => x.ID == IDProduct);
            if (productEntity != null)
            {
            }
            else
            {
                productEntity.Deleted = true;
                productEntity.Date_Delete = DateTime.Now;
                await _baseRepositoryProduct.UpdateAsync(productEntity);
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

        public IEnumerable<DataResponse_Product> GetAllSale()
        {
            var query = _baseRepositoryProduct.GetQueryable(record => record.Deleted == false);
            query = query.Where(record => record.Sale == true);
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
