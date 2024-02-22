using Microsoft.Identity.Client;
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
                    Price = dataproduct.Price,
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

        public async Task Create(DataRequest_DetailCart data)
        {
            var Cart = await _cartRepository.GetAsync(record => record.AccountID == data.accountID);
            var product = await _productRepository.GetByIDAsync(data.productID);
            var entity = new Detail_Cart
            {
                Cart = Cart,
                ProductID = data.productID,
                Quantity = data.quantity,
                Price = product.Price,
                Cash = (decimal)data.quantity * product.Price,
            };
            await _detailCartRepository.CreateAsync(entity);
            var dataproduct = _productRepository.GetQueryable(record => record.ID == data.productID);
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
        public async Task Delete(long ID)
        {
            await _detailCartRepository.DeleteAsync(ID);
        }

        public async Task Update(long ID, DataRequest_DetailCart data)
        {
            var Cart = await _cartRepository.GetAsync(record => record.AccountID == data.accountID);
            var detail = await _detailCartRepository.GetAsync(record => record.CartID == Cart.ID);

            if (detail != null)
            {
                var product = await _productRepository.GetAsync(record => record.ID == data.productID);
                var priceproduct = product.Sale == false ? product.Price : product.Price * product.Price_Sale;
                detail.ProductID = data.productID;
                detail.Quantity = data.quantity;
                detail.Price = priceproduct;
                detail.Cash = (decimal)data.quantity * priceproduct;
                await _detailCartRepository.UpdateAsync(detail);
            }
        }

        public async Task<IEnumerable<DataResponse_DetailCart>> GetByAccount(long idUser)
        {
            var DataCart = await _cartRepository.GetAsync(record => record.AccountID == idUser);
            var Data = await _detailCartRepository.GetAllAsync(record => record.CartID == DataCart.ID);
            return Data.Select(item => new DataResponse_DetailCart
            {
                cartID = item.CartID,
                productID = (long)item.ProductID,
                quantity = item.Quantity,
                price = item.Price,
                dataResponseProduct = ByIDProduct(item.ProductID),
            });
        }
        public IEnumerable<DataResponse_Product> ByIDProduct(long? IDproduct)
        {
            var Data = _productRepository.GetQueryable(record => record.ID == IDproduct);
            return Data.Select(item => new DataResponse_Product
            {
                metaProduct = item.Meta_Product,
                productID = item.ID,
                username = item.Account.User_Name,
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
        }
    }
}
