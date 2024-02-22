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
    public class StatusBillsServices : IStatusBillsServices
    {
        private readonly IBaseRepository<Status_Bill> _repository;

        public StatusBillsServices(IBaseRepository<Status_Bill> repository)
        {
            _repository = repository;
        }

        public async Task Create(DataRequest_StatusBill data)
        {
            var Entity = new Status_Bill
            {
                Status_Name = data.status_Name,
                Deleted = false
            };
            await _repository.CreateAsync(Entity);
        }

        public async Task Delete(long ID)
        {
            try
            {
                var Item = await _repository.GetByIDAsync(ID);
                Item.Deleted = true;
                await _repository.UpdateAsync(Item);
            }
            catch
            {
            }
        }

        public IEnumerable<DataResponse_StatusBill> GetAll()
        {
            var query = _repository.GetQueryable();
            return query.Select(item => new DataResponse_StatusBill
            {
                status_Name = item.Status_Name,
                statusBillId = item.ID
            });
        }

        public async Task Update(long ID, DataRequest_StatusBill data)
        {
            await Create(data);
        }
    }
}
