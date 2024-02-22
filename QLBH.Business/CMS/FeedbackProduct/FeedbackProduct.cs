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
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Services.Common.CommandLine;
using static QLBH.Commons.Enums;

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

        public async Task<Response_Feedback> Create(Request_Feedback item)
        {

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
        public async Task<bool> Delete(long ID)
        {
            var feedback = await _baseRepositoryFeedback.GetByIDAsync(ID);
            var product = await _baseRepositoryProduct.GetByIDAsync(feedback.Product.ID);
            bool checkDelete = await _baseRepositoryFeedback.DeleteAsync(ID);
            var Stars = (await _baseRepositoryFeedback.GetAllAsync(record => record.Product.ID ==
                        product.ID))
                        .Select(item => (int)item.star).ToList();
            product.Evaluate = EvaluateStar(Stars);
            await _baseRepositoryProduct.UpdateAsync(product);
            return checkDelete;
        }

        public async Task<Response_Feedback> Update(long ID, Request_Feedback item)
        {
            var entity = await _baseRepositoryFeedback.GetAsync(record => record.ID == ID);
            if (entity.AccountID == item.accountId)
            {
                entity.FeedBack_Quality = item.FeedBack_Quality;
                entity.star = item.Star;
                entity.Opinion = item.Opinion;
            }
            await _baseRepositoryFeedback.UpdateAsync(entity);
            return new Response_Feedback
            {
                FeedBack_Quality = entity.FeedBack_Quality,
                Opinion = entity.Opinion,
                Star = entity.star,
            };
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
                FeedBack_Quality = item.FeedBack_Quality,
                Opinion = item.Opinion,
                Star = item.star,
            });
        }

        public async Task<IEnumerable<Response_Feedback>> Create(long accountId = 0, long productId = 0, Request_Feedback data)
        {
            var entity = new FeedBack();
            entity.AccountID = data.accountId;
            entity.Opinion = data.Opinion;
            entity.FeedBack_Quality = data.FeedBack_Quality;
            entity.star = data.Star;
            if (productId > 0)
            {
                entity.ProductID = productId;
            }
            await _baseRepositoryFeedback.CreateAsync(entity);
            return new Response_Feedback
            {
                FeedBack_Quality = entity.FeedBack_Quality,
                Opinion = entity.Opinion,
                Star = entity.star,
            };
        }
    }
}
