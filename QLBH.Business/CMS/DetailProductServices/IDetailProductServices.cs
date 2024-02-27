using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IDetailProductServices : IReponsitory<DataRequest_DetailProduct, long>
    {
        Task CreateAsync(long accountId, DataRequest_DetailProduct data);
        Task Delete(long accountID, long iD);
    }
}
