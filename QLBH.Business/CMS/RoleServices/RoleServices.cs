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

        public Task Create(DataRequest_Role data)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<DataResponse_Role> GetAll()
        {
            var query = _roleRepository.GetQueryable();
            return query.Select(record => new DataResponse_Role
            {
                roleID = record.ID,
                roleName = record.Role_Name
            }).ToList();
        }

        public Task<DataResponse_Role> Update(long ID, DataRequest_Role data)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(DataRequest_Role data)
        {
            Role entity = await _roleRepository.GetByIDAsync(data.iD);
            entity.Role_Name = data.roleName;
            await _roleRepository.UpdateAsync(entity);
        }

        Task IReponsitory<DataRequest_Role, long>.Update(long iD, DataRequest_Role data)
        {
            throw new NotImplementedException();
        }
    }
}
