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
        Task Create(DataRequest_Bill item);
        Task Delete(long ID);
        Task DeleteInvoice(long invoiceId);
        Task Update(long ID);
        IEnumerable<DataResponse_Bill> GetBillAsync();
        IEnumerable<DataResponse_Bill> GetBillAsync(long accountId = 0, bool IsDelete = false);
        IEnumerable<DataResponse_Bill> GetBillAsync(bool IsDelete = true);
        Task<DataResponse_Bill> GetByIDAsync(long ID);
    }
}
