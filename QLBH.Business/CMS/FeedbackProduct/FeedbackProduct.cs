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
            var product = await _baseRepositoryProduct.GetAsync(record => record.ID == item.productID);
            product.FeedBack = new List<FeedBack>
            {
                new FeedBack
                {
                    AccountID = item.accountID,
                    Opinion = item.opinion,
                    FeedBack_Quality=item.feedBackQuality,
                    star = item.star
                }
            };
            product.Evaluate = EvaluateStar(product.FeedBack.Select(x => (int)x.star).ToList());
            await _baseRepositoryProduct.UpdateAsync(product);
        }
        private decimal EvaluateStar(List<int> ints)
        {
            decimal result = 0;
            foreach (int i in ints)
            {
                result += i;
            }
            return (decimal)(result / ints.Count());
        }
        public async Task Delete(long ID)
        {
            var feedback = await _baseRepositoryFeedback.GetByIDAsync(ID);
            var product = await _baseRepositoryProduct.GetByIDAsync(feedback.Product.ID);
            bool checkDelete = await _baseRepositoryFeedback.DeleteAsync(ID);
            var Stars = (await _baseRepositoryFeedback.GetAllAsync(record => record.Product.ID ==
                        product.ID))
                        .Select(item => (int)item.star).ToList();
            product.Evaluate = EvaluateStar(Stars);
            await _baseRepositoryProduct.UpdateAsync(product);
        }

        public async Task Update(long ID, Request_Feedback item)
        {
            var entity = await _baseRepositoryFeedback.GetAsync(record => record.ID == ID);
            if (entity.AccountID == item.accountID)
            {
                entity.FeedBack_Quality = item.feedBackQuality;
                entity.star = item.star;
                entity.Opinion = item.opinion;
            }
            await _baseRepositoryFeedback.UpdateAsync(entity);
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
