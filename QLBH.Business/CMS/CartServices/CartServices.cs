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

        public async Task<DataResponse_Cart> Create(DataRequest_Cart data)
        {
            if (!_cartRepository.GetQueryable(record => record.AccountID == data.AccountID).Any())
            {
                var entity = new Cart
                {
                    AccountID = data.AccountID
                };
                await _cartRepository.CreateAsync(entity);
                return new DataResponse_Cart
                {
                    AccountID = entity.AccountID
                };
            }
            throw new Exception("Cannot be empty");
        }

        public Task<bool> Delete(long ID)
        {
            throw new Exception("Is not allowed");
        }

        public async Task<IEnumerable<Cart>> GetAllCart()
        {
            return await _cartRepository.GetAllAsync();
        }

        public Task<DataResponse_Cart> Update(long ID, DataRequest_Cart data)
        {
            throw new Exception("Is not allowed");
        }
    }
}
