using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IVoucherServices : IReponsitory<DataRequest_Voucher, long>
    {
        IEnumerable<DataResponse_Voucher> GetAll();
        IEnumerable<DataResponse_Voucher> GetAll(long accountID);
        Task<DataResponse_Voucher> GetByID(long ID);
    }
}
