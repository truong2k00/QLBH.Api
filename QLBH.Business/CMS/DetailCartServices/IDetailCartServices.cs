using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IDetailCartServices : IReponsitory<DataRequest_DetailCart, DataResponse_DetailCart, long>
    {
        Task<bool> AddCart(long idUser, string meta);
        Task<IEnumerable<DataResponse_DetailCart>> GetByAccount(long idUser);
    }
}
