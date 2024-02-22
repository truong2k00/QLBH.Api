using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IRoleServices : IReponsitory<DataRequest_Role, DataResponse_Role, long>
    {
        Task<DataResponse_Role> UpdateAsync(DataRequest_Role data);
        Task<List<DataResponse_Role>> GetAll();
    }
}
