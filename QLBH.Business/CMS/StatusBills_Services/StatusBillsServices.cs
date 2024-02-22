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

        public async Task<DataResponse_StatusBill> Create(DataRequest_StatusBill data)
        {
            var Entity = new Status_Bill
            {
                Status_Name = data.Status_Name,
                Deleted = false
            };
            await _repository.CreateAsync(Entity);
            return new DataResponse_StatusBill
            {
                Status_Name = Entity.Status_Name,
                StatusBillId = Entity.ID
            };
        }

        public async Task<bool> Delete(long ID)
        {
            try
            {
                var Item = await _repository.GetByIDAsync(ID);
                Item.Deleted = true;
                await _repository.UpdateAsync(Item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<DataResponse_StatusBill>> GetAll()
        {
            var Datas = await _repository.GetAllAsync();
            return Datas.Select(item => new DataResponse_StatusBill
            {
                Status_Name = item.Status_Name,
                StatusBillId = item.ID
            });
        }

        public async Task<DataResponse_StatusBill> Update(long ID, DataRequest_StatusBill data)
        {
            if (await Delete(ID))
            {
                return await Create(data);
            }
            else return null;
        }
    }
}
