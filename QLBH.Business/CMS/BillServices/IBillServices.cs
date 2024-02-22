using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IBillServices
    {
        Task<DataResponse_Bill> Create(DataRequest_Bill item);
        Task<bool> Delete(long ID);
        Task<DataResponse_Bill> DeleteInvoice(long invoiceId);
        Task<DataResponse_Bill> Update(long ID);
        IEnumerable<DataResponse_Bill> GetBillAsync();
        IEnumerable<DataResponse_Bill> GetBillAsync(long accountId = 0, bool IsDelete = false);
        IEnumerable<DataResponse_Bill> GetBillAsync(bool IsDelete = true);
        Task<DataResponse_Bill> GetByIDAsync(long ID);
    }
}
