using Microsoft.AspNetCore.Http;
using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business.CMS
{
    public interface IProductCategoryServices : IReponsitory<DataRequest_ProductCategory, long>
    {
        Task<IEnumerable<DataResponse_ProductCategory>> GetAll();
    }
}
