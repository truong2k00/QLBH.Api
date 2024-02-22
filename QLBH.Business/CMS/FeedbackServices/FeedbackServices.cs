using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business.CMS.sss
{
    internal class FeedbackServices : IFeedbackServices
    {
        private readonly IBaseRepository<FeedBack> _feedbackRepository;

        public FeedbackServices(IBaseRepository<FeedBack> feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<DataResponse_Feedback> Create(DataRequest_Feedback data)
        {
            var entity = new FeedBack
            {
                FeedBack_Quality = data.FeedBack_Quality,
                Opinion = data.Opinion,
                AccountID = data.AccountID,
                ProductID = data.ProductID,
                star = data.star
            };
            await _feedbackRepository.CreateAsync(entity);
            return new DataResponse_Feedback
            {
                FeedBack_Quality = entity.FeedBack_Quality,
                Opinion = entity.Opinion,
                AccountID = entity.AccountID,
                ProductID = entity.ProductID,
                star = entity.star
            };
        }

        public async Task<bool> Delete(long ID)
        {
            return await _feedbackRepository.DeleteAsync(ID);
        }

        public async Task<DataResponse_Feedback> Update(long ID, DataRequest_Feedback data)
        {
            var entity = new FeedBack
            {
                FeedBack_Quality = data.FeedBack_Quality,
                Opinion = data.Opinion,
                AccountID = data.AccountID,
                ProductID = data.ProductID,
                star = data.star
            };
            await _feedbackRepository.DeleteAsync(ID);
            await _feedbackRepository.CreateAsync(entity);
            return new DataResponse_Feedback
            {
                FeedBack_Quality = entity.FeedBack_Quality,
                Opinion = entity.Opinion,
                AccountID = entity.AccountID,
                ProductID = entity.ProductID,
                star = entity.star
            };
        }
    }
}
