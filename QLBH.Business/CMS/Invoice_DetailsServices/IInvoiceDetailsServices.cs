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
        Task<DataResponse_InvoiceDetail> Update(long accountId,long invoiceId,DataRequest_InvoidDetails data);
        Task<bool> Delete(long ID);
        Task<bool> DeleteAsync(long billId);
        IEnumerable<DataResponse_InvoiceDetail> GetAll(long idBill);
        Task<IEnumerable<DataResponse_InvoiceDetail>> GetAll();
        Task<Invoice_Details> GetByID(long Id);
    }
}
