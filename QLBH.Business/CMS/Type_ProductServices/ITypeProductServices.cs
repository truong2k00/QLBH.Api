using Microsoft.AspNetCore.Http;
using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface ITypeProductServices : IReponsitory<DataRequest_TypeProduct, long>
    {
        IEnumerable<DataResponse_TypeProduct> GetAll();
        IEnumerable<DataResponse_TypeProduct> GetAll(long productID=0);
    }
}
