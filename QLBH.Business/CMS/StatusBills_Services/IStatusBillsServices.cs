using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IStatusBillsServices : IReponsitory<DataRequest_StatusBill, long>
    {
        Task<IEnumerable<DataResponse_StatusBill>> GetAll();
    }
}
