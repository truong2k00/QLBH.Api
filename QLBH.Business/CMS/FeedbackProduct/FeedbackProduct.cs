using Microsoft.AspNetCore.Http;
using QLBH.Models.Entities;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Models;
using Microsoft.VisualStudio.Services.Identity;
using Org.BouncyCastle.Tls;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLBH.Business
{
    public class FeedbackProduct : IFeedbackServices<Response_Feedback>
    {
        private readonly IBaseRepository<Product> _baseRepositoryProduct;
        private readonly IBaseRepository<FeedBack> _baseRepositoryFeedback;

        public FeedbackProduct(IBaseRepository<Product> baseRepositoryProduct, IBaseRepository<FeedBack> baseRepositoryFeedback)
        {
            _baseRepositoryProduct = baseRepositoryProduct;
            _baseRepositoryFeedback = baseRepositoryFeedback;
        }

        public async Task Create(Request_Feedback item)
        {
            try
            {
                var entity = new FeedBack
                {
                    AccountID = item.accountID,
                    ProductID = item.productID,
                    Opinion = item.opinion,
                    FeedBack_Quality = item.feedBackQuality,
                    star = item.star
                };
                await _baseRepositoryFeedback.CreateAsync(entity);
                await UpdateEvaluate(entity.ProductID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task Delete(long id)
        {
            try
            {
                await _baseRepositoryFeedback.DeleteAsync(id);
                var query = _baseRepositoryFeedback.GetQueryable(record => record.ID == id);
                var productID = query.Select(item => item.ProductID).FirstOrDefault();
                await UpdateEvaluate(productID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }
        public async Task UpdateEvaluate(long productID)
        {
            var product = await _baseRepositoryProduct.GetAsync(record => record.ID == productID);
            product.Evaluate = (decimal)_baseRepositoryFeedback.GetQueryable(record => record.ProductID == product.ID).Select(item => (int)item.star).ToList().Average();
            await _baseRepositoryProduct.UpdateAsync(product);
        }
        public async Task Update(long ID, Request_Feedback item)
        {
            try
            {
                var entity = await _baseRepositoryFeedback.GetAsync(record => record.ID == ID);
                if (entity.AccountID == item.accountID)
                {
                    entity.FeedBack_Quality = item.feedBackQuality;
                    entity.star = item.star;
                    entity.Opinion = item.opinion;
                    await _baseRepositoryFeedback.UpdateAsync(entity);
                    await UpdateEvaluate(entity.ProductID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }

        public IEnumerable<Response_Feedback> Get(long accountId = 0, long productId = 0)
        {
            var query = _baseRepositoryFeedback.GetQueryable();
            if (accountId > 0)
            {
                query.Where(record => record.AccountID == accountId);
            }
            if (productId > 0)
            {
                query.Where(record => record.ProductID == productId);
            }
            return query.Select(item => new Response_Feedback
            {
                feedBack_Quality = item.FeedBack_Quality,
                opinion = item.Opinion,
                star = item.star,
            });
        }
    }
}
