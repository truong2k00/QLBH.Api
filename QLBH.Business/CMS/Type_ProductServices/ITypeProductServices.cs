using Microsoft.AspNetCore.Http;
using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface ITypeProductServices : IReponsitory<DataRequest_TypeProduct, DataResponse_TypeProduct, long>
    {
        Task<IEnumerable<DataResponse_TypeProduct>> GetAll();
        Task<IEnumerable<DataResponse_TypeProduct>> GetByIDProduct(long IDProduct);
    }
}
