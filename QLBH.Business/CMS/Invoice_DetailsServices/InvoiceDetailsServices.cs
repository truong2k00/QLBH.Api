using Microsoft.VisualStudio.Services.Identity;
using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using QLBH.Commons;

namespace QLBH.Business
{
    public class InvoiceDetailsServices : IInvoiceDetailsServices
    {
        private readonly IBaseRepository<Invoice_Details> _InvoiceDetailsServices;

        public InvoiceDetailsServices(IBaseRepository<Invoice_Details> invoiceDetailsServices)
        {
            _InvoiceDetailsServices = invoiceDetailsServices;
        }

        public async Task Delete(long ID)
        {
            try
            {
                await _InvoiceDetailsServices.DeleteAsync(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(Common_Constants.BaseOperation.delete, ex);
            }
        }
        public async Task DeleteAsync(long billId)
        {
            try
            {
                var query = _InvoiceDetailsServices.GetQueryable(record => record.BillID == billId);
                foreach (var item in query)
                {
                    item.Deleted = true;
                    await _InvoiceDetailsServices.UpdateAsync(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Common_Constants.ErrorExists.EmptyList, ex);
            }
        }

        public IEnumerable<DataResponse_InvoiceDetail> GetAll()
        {
            return GetAll(0);
        }

        public IEnumerable<DataResponse_InvoiceDetail> GetAll(long idBill)
        {
            var query = _InvoiceDetailsServices.GetQueryable();
            if (idBill != 0)
            {
                query.Where(record => record.BillID == idBill);
            }
            return query.Select(item => new DataResponse_InvoiceDetail
            {
                productID = item.ID,
                quantity = item.Quantity,
                unitPrice = item.UnitPrice,
                price = item.Price,
                billId = item.BillID,
            });
        }

        public async Task<Invoice_Details> GetByID(long Id)
        {
            return await _InvoiceDetailsServices.GetAsync(reocrd => reocrd.ID == Id);
        }

        public async Task Update(long accountId, long invoiceId, DataRequest_InvoidDetails data)
        {
            try
            {
                var query = _InvoiceDetailsServices.GetQueryable(record => record.ID == invoiceId);
                if (accountId != 0)
                {
                    query = query.Where(record => record.Bill.AccountID == accountId);
                }
                var item = query.FirstOrDefault();
                item.UnitPrice = data.unitPrice;
                item.Price = data.price;
                await _InvoiceDetailsServices.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(Common_Constants.ErrorExists.EmptyList, ex);
            }
        }
    }
}
