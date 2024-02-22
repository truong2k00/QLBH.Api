using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public class RefeshTokenServices : IRefeshTokenServices
    {
        private readonly IBaseRepository<RefeshToken> _repository;

        public RefeshTokenServices(IBaseRepository<RefeshToken> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<DataResponse_RefeshToken>> GetAll(long AccountID)
        {
            var Datas = await _repository.GetAllAsync(record => record.AccountID == AccountID);
            return Datas.Select(item => new DataResponse_RefeshToken
            {
                refeshTokenID = item.ID,
                accountID = AccountID,
                token = item.Token,
                dateExpired = item.Date_Expired,
            });
        }
        public async Task<IEnumerable<DataResponse_RefeshToken>> GetAll()
        {
            var Datas = await _repository.GetAllAsync();
            return Datas.Select(item => new DataResponse_RefeshToken
            {
                refeshTokenID = item.ID,
                accountID = item.AccountID,
                token = item.Token,
                dateExpired = item.Date_Expired,
            });
        }
    }
}
