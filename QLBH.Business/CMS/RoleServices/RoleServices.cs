using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public class RoleServices : IRoleServices
    {
        private readonly IBaseRepository<Role> _roleRepository;

        public RoleServices(IBaseRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<DataResponse_Role> Create(DataRequest_Role data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DataResponse_Role>> GetAll()
        {
            var Entities = await _roleRepository.GetAllAsync();
            return Entities.Select(record => new DataResponse_Role
            {
                Role_ID = record.ID,
                Role_Name = record.Role_Name
            }).ToList();
        }

        public Task<DataResponse_Role> Update(long ID, DataRequest_Role data)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse_Role> UpdateAsync(DataRequest_Role data)
        {
            Role entity = await _roleRepository.GetByIDAsync(data.ID);
            entity.Role_Name = data.RoleName;
            await _roleRepository.UpdateAsync(entity);
            return new DataResponse_Role
            {
                Role_ID = entity.Role_ID,
                Role_Name = entity.Role_Name
            };
        }
    }
}
