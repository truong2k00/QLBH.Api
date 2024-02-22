using Microsoft.Identity.Client;
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

        public async Task Create(DataRequest_Voucher data)
        {
            var Entity = new Voucher
            {
                VoucherId = Guid.NewGuid().ToString(),
                AccountID = data.accountID,
                VoucherName = data.voucherName,
                Release_Date = DateTime.Now,
                Expiration_Date = DateTime.Now.AddDays(data.expirationDate),
                Quantity = data.quantity,
                Deleted = false,
                Reducted_Value = data.reductedValue,
                Work = false
            };
            var Data = await _repository.CreateAsync(Entity);
        }

        public async Task Delete(long ID)
        {
            try
            {
                var Entity = await _repository.GetByIDAsync(ID);
                Entity.Deleted = true;
                await _repository.UpdateAsync(Entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DataResponse_Voucher> GetByID(long iD)
        {
            var data = await _repository.GetAsync(record => record.ID == iD);
            return new DataResponse_Voucher
            {
                voucherID = data.ID,
                voucher = data.VoucherId,
                voucherName = data.VoucherName,
                releaseDate = data.Release_Date,
                expirationDate = data.Expiration_Date,
                quantity = data.Quantity,
                reducted_Value = data.Reducted_Value,
                accountID = data.AccountID,
                work = data.Work,
            };
        }

        public IEnumerable<DataResponse_Voucher> GetAll(long accountID=0)
        {
            var query = _repository.GetQueryable();
            if (accountID != 0)
            {
                query = query.Where(record => record.AccountID == accountID);
            }
            return query.Select(item => new DataResponse_Voucher
            {
                voucherID = item.ID,
                voucher = item.VoucherId,
                voucherName = item.VoucherName,
                releaseDate = item.Release_Date,
                expirationDate = item.Expiration_Date,
                quantity = item.Quantity,
                reducted_Value = item.Reducted_Value,
                accountID = item.AccountID,
                userName = item.Account.User_Name,
                work = item.Work,
            });
        }

        public IEnumerable<DataResponse_Voucher> GetAll()
        {
            return GetAll(0);
        }

        public async Task Update(long ID, DataRequest_Voucher data)
        {
            await Delete(ID);
        }
    }
}
