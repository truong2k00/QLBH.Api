using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IInvoiceDetailsServices
    {
        Task Update(long accountId,long invoiceId, DataRequest_InvoiceDetails data);
        Task Delete(long ID);
        Task DeleteAsync(long billId);
        IEnumerable<DataResponse_InvoiceDetail> GetAll(long idBill);
        IEnumerable<DataResponse_InvoiceDetail> GetAll();
        Task<Invoice_Details> GetByID(long Id);
    }
}
