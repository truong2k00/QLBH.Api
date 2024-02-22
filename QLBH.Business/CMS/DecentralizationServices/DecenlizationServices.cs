using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public class DecenlizationServices : IDecentralizationServices
    {
        private readonly IBaseRepository<Decentralization> _decentralizationRepository;
        private readonly IBaseRepository<Role> _roleRepository;
        private readonly IBaseRepository<Account> _accountRepository;

        public DecenlizationServices(IBaseRepository<Decentralization> decentralizationRepository
            , IBaseRepository<Role> roleRepository
            , IBaseRepository<Account> accountRepository)
        {
            _roleRepository = roleRepository;
            _decentralizationRepository = decentralizationRepository;
            _accountRepository = accountRepository;
        }

        public async Task Create(DataRequest_Decenlization data)
        {
            Role role = await _roleRepository.GetAsync(record => record.Role_ID == Convert.ToInt64(data.role));
            var entity = new Decentralization
            {
                AccountID = data.accountID,
                role = data.role,
                RoleID = role.ID
            };
            await _decentralizationRepository.CreateAsync(entity);
            var RoleNames = _decentralizationRepository.GetQueryable(record => record.AccountID == entity.AccountID)
                            .Select(record => record.Role.Role_Name).ToList();
        }

        public async Task Delete(long ID)
        {
            await _decentralizationRepository.DeleteAsync(ID);
        }

        public IEnumerable<DataResponse_Decenlization> GetAllRole()
        {
            var Query = _accountRepository.GetQueryable();
            return Query.Select(item => new DataResponse_Decenlization
            {
                accountID = item.ID,
                user = item.User_Name,
                roles = item.Decentralizations.Select(item => item.Role.Role_Name).ToList()
            }).AsEnumerable();
        }

        public DataResponse_Decenlization GetAllRole(long accountId)
        {
            var Query = _accountRepository.GetQueryable(record => record.ID == accountId);
            var Data = Query.Select(item => new DataResponse_Decenlization
            {
                accountID = item.ID,
                user = item.User_Name,
                roles = item.Decentralizations.Select(item => item.Role.Role_Name).ToList()
            }).FirstOrDefault();
            return Data;
        }

        public async Task Update(long ID, DataRequest_Decenlization data)
        {
            var item = await _decentralizationRepository.GetAsync(record => record.ID == ID);
            item.RoleID = Convert.ToInt64(data.role);
            await _decentralizationRepository.UpdateAsync(item);
            await Delete(ID);
            var RoleNames = _decentralizationRepository.GetQueryable(record => record.AccountID == item.AccountID)
                            .Select(record => record.Role.Role_Name).ToList();

        }
    }
}
