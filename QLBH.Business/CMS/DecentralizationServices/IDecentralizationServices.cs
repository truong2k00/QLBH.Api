using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IDecentralizationServices : IReponsitory<DataRequest_Decenlization, DataResponse_Decenlization, long>
    {
        IEnumerable<DataResponse_Decenlization> GetAllRole();
        DataResponse_Decenlization GetAllRole(long accountId);
    }
}
