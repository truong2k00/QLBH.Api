using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IRoleServices : IReponsitory<DataRequest_Role, long>
    {
        Task UpdateAsync(DataRequest_Role data);
        List<DataResponse_Role> GetAll();
    }
}
