using QLBH.Commons;
using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Repository;

namespace QLBH.Business
{
    public class CartServices : ICartServices
    {
        private readonly IBaseRepository<Cart> _cartRepository;

        public CartServices(IBaseRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task Create(DataRequest_Cart data)
        {
            try
            {
                if (!_cartRepository.GetQueryable(record => record.AccountID == data.accountID).Any())
                {
                    var entity = new Cart
                    {
                        AccountID = data.accountID
                    };
                    await _cartRepository.CreateAsync(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Common_Constants.BaseOperation.create, ex);
            }
        }

        public Task Delete(long iD)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cart> GetAllCart()
        {
            return _cartRepository.GetQueryable();
        }

        public Task Update(long iD, DataRequest_Cart data)
        {
            throw new NotImplementedException();
        }
    }
}
