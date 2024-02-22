using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Commons.Common_Page;
using QLBH.Models;

namespace QLBH.Business
{
    public interface IAddressReceive<TEntity,Bind> : IReponsitory<Request_AddressReceive,long>
    {
        PageResult<TEntity> GetAll(Pagination pagination,string KeyWord);
        PageResult<TEntity> GetAll(long? AccountID, Pagination pagination, string KeyWord);
        Task<TEntity> GetByID(Bind AddressID);
    }
}
