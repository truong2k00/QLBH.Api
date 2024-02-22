using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IDetailProductServices : IReponsitory<DataRequest_DetailProduct,DataResponse_DetailProduct,long>
    {
        Task<DataResponse_DetailProduct> CreateAsync(long accountId, DataRequest_DetailProduct data);
    }
}
