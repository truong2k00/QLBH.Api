using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Repository;

namespace QLBH.Business
{
    public class VoucherServices : IVoucherServices
    {
        private readonly IBaseRepository<Voucher> _repository;

        public VoucherServices(IBaseRepository<Voucher> repository)
        {
            _repository = repository;
        }

        public async Task<DataResponse_Voucher> Create(DataRequest_Voucher data)
        {
            var Entity = new Voucher
            {
                VoucherId = Guid.NewGuid().ToString(),
                AccountID = data.AccountID,
                VoucherName = data.VoucherName,
                Release_Date = DateTime.Now,
                Expiration_Date = DateTime.Now.AddDays(data.Expiration_Date),
                Quantity = data.Quantity,
                Deleted = false,
                Reducted_Value = data.Reducted_Value,
                Work = false
            };
            var Data = await _repository.CreateAsync(Entity);
            return new DataResponse_Voucher
            {
                ID = Data.ID,
                VoucherId = Data.VoucherId,
                VoucherName = Data.VoucherName,
                Release_Date = Data.Release_Date,
                Expiration_Date = Data.Expiration_Date,
                Quantity = Data.Quantity,
                Reducted_Value = Data.Reducted_Value,
                AccountID = Data.AccountID,
                Work = Data.Work,
            };
        }

        public async Task<bool> Delete(long ID)
        {
            try
            {
                var Entity = await _repository.GetByIDAsync(ID);
                Entity.Deleted = true;
                await _repository.UpdateAsync(Entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<DataResponse_Voucher> GetByID(long ID)
        {
            var Data = await _repository.GetByIDAsync(ID);
            return new DataResponse_Voucher
            {
                ID = Data.ID,
                VoucherId = Data.VoucherId,
                VoucherName = Data.VoucherName,
                Release_Date = Data.Release_Date,
                Expiration_Date = Data.Expiration_Date,
                Quantity = Data.Quantity,
                Reducted_Value = Data.Reducted_Value,
                AccountID = Data.AccountID,
                Work = Data.Work,
            };
        }

        public IEnumerable<DataResponse_Voucher> GetByIDAccount(long AccountID)
        {
            var Query = _repository.GetQueryable(record=>record.AccountID == AccountID);
            return Query.Select(item => new DataResponse_Voucher
            {
                ID = item.ID,
                VoucherId = item.VoucherId,
                VoucherName = item.VoucherName,
                Release_Date = item.Release_Date,
                Expiration_Date = item.Expiration_Date,
                Quantity = item.Quantity,
                Reducted_Value = item.Reducted_Value,
                AccountID = item.AccountID,
                UserName = item.Account.User_Name,
                Work = item.Work,
            });
        }

        public IEnumerable<DataResponse_Voucher> GetVouchers()
        {
            var Query = _repository.GetQueryable();
            return Query.Select(item => new DataResponse_Voucher
            {
                ID = item.ID,
                VoucherId = item.VoucherId,
                VoucherName = item.VoucherName,
                Release_Date = item.Release_Date,
                Expiration_Date = item.Expiration_Date,
                Quantity = item.Quantity,
                Reducted_Value = item.Reducted_Value,
                AccountID = item.AccountID,
                UserName = item.Account.User_Name,
                Work = item.Work,
            });
        }

        public async Task<DataResponse_Voucher> Update(long ID, DataRequest_Voucher data)
        {
            if (await Delete(ID))
            {
                return await Create(data);
            }
            else return null;
        }
    }
}
