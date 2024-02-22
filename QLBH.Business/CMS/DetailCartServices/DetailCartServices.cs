using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.Identity;
using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public class DetailCartServices : IDetailCartServices
    {
        private readonly IBaseRepository<Detail_Cart> _detailCartRepository;
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IBaseRepository<Cart> _cartRepository;

        public DetailCartServices(IBaseRepository<Detail_Cart> detailCartRepository
            , IBaseRepository<Product> productRepository,
            IBaseRepository<Cart> cartRepository)
        {
            _productRepository = productRepository;
            _detailCartRepository = detailCartRepository;
            _cartRepository = cartRepository;
        }

        public async Task<bool> AddCart(long idUser, string meta)
        {
            var dataproduct = await _productRepository.GetAsync(record => record.Meta_Product == meta);
            var cart = await _cartRepository.GetAsync(record => record.AccountID == idUser);
            cart.Detail_Cart = new List<Detail_Cart>
            {
                new Detail_Cart
                {
                    Cart = cart,
                    Product = dataproduct,
                    Price = dataproduct.Sale ? dataproduct.Price * dataproduct.Price_Sale : dataproduct.Price,
                    Quantity = dataproduct.Quantity,
                    Cash = (decimal)dataproduct.Price * dataproduct.Quantity,
                }
            };
            try
            {
                await _cartRepository.UpdateAsync(cart);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<DataResponse_DetailCart> Create(DataRequest_DetailCart data)
        {
            var Cart = await _cartRepository.GetAsync(record => record.AccountID == data.AccountID);
            var product = await _productRepository.GetByIDAsync(data.ProductID);
            var entity = new Detail_Cart
            {
                Cart = Cart,
                ProductID = data.ProductID,
                Quantity = data.Quantity,
                Price = product.Sale ? product.Price * product.Price_Sale : product.Price,
                Cash = (decimal)data.Quantity * product.Price,
            };
            await _detailCartRepository.CreateAsync(entity);
            var dataproduct = _productRepository.GetQueryable(record => record.ID == data.ProductID);
            return new DataResponse_DetailCart
            {
                CartID = entity.CartID,
                ProductID = (long)entity.ProductID,
                Quantity = entity.Quantity,
                Price = entity.Price,
                DataResponse_Product = dataproduct.Select(item => new DataResponse_Product
                {
                    Meta_Product = item.Meta_Product,
                    Product_ID = item.ID,
                    Username = item.Account.User_Name,
                    Product_Name = item.Product_Name,
                    Product_Description = item.Product_Description,
                    Is_New = item.Is_New,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    Sale = item.Sale,
                    Price_Sale = item.Price_Sale,
                    Evaluate = item.Evaluate,
                    ImageProduct = imageURL(item.ImageProduct.ToList())
                }).AsEnumerable()
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
        public async Task<bool> Delete(long ID)
        {
            return await _detailCartRepository.DeleteAsync(ID);
        }

        public async Task<DataResponse_DetailCart> Update(long ID, DataRequest_DetailCart data)
        {
            var Cart = await _cartRepository.GetAsync(record => record.AccountID == data.AccountID);
            var detail = await _detailCartRepository.GetAsync(record => record.CartID == Cart.ID);

            if (detail != null)
            {
                var product = await _productRepository.GetAsync(record => record.ID == data.ProductID);
                var priceproduct = product.Sale == false ? product.Price : product.Price * product.Price_Sale;
                detail.ProductID = data.ProductID;
                detail.Quantity = data.Quantity;
                detail.Price = priceproduct;
                detail.Cash = (decimal)data.Quantity * priceproduct;
                await _detailCartRepository.UpdateAsync(detail);
            }
            return new DataResponse_DetailCart
            {
                AccountID = Cart.ID,
                ProductID = detail.ProductID,
                Quantity = detail.Quantity,
                CartID = detail.CartID,
                Price = detail.Price,
                Cash = detail.Cash
            };
        }

        public async Task<IEnumerable<DataResponse_DetailCart>> GetByAccount(long idUser)
        {
            var DataCart = await _cartRepository.GetAsync(record => record.AccountID == idUser);
            var Data = await _detailCartRepository.GetAllAsync(record => record.CartID == DataCart.ID);
            return Data.Select(item => new DataResponse_DetailCart
            {
                CartID = item.CartID,
                ProductID = (long)item.ProductID,
                Quantity = item.Quantity,
                Price = item.Price,
                DataResponse_Product = ByIDProduct(item.ProductID),
            });
        }
        public IEnumerable<DataResponse_Product> ByIDProduct(long? IDproduct)
        {
            var Data = _productRepository.GetQueryable(record => record.ID == IDproduct);
            return Data.Select(item => new DataResponse_Product
            {
                Meta_Product = item.Meta_Product,
                Product_ID = item.ID,
                Username = item.Account.User_Name,
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
        }
    }
}
