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

        public async Task<bool> Delete(long ID)
        {
            return await _InvoiceDetailsServices.DeleteAsync(ID);
        }
        public async Task<bool> DeleteAsync(long billId)
        {
            var query = _InvoiceDetailsServices.GetQueryable(record => record.BillID == billId);
            if (query.Any())
            {
                foreach (var item in query)
                {
                    item.Deleted = true;
                    await _InvoiceDetailsServices.UpdateAsync(item);
                }
                return true;
            }
            throw new Exception(Common_Constants.ErrorExists.EmptyList);
        }

        public async Task<IEnumerable<DataResponse_InvoiceDetail>> GetAll()
        {
            var Query = await _InvoiceDetailsServices.GetAllAsync();
            return Query.Select(item => new DataResponse_InvoiceDetail
            {
                ProductID = item.ID,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Price = item.Price,
                billId = item.BillID,
            });
        }

        public IEnumerable<DataResponse_InvoiceDetail> GetAll(long idBill)
        {
            var Query = _InvoiceDetailsServices.GetQueryable(record => record.BillID == idBill);
            return Query.Select(item => new DataResponse_InvoiceDetail
            {
                ProductID = item.ID,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Price = item.Price,
                billId = item.BillID,
            });
        }

        public async Task<Invoice_Details> GetByID(long Id)
        {
            return await _InvoiceDetailsServices.GetAsync(reocrd => reocrd.ID == Id);
        }

        public async Task<DataResponse_InvoiceDetail> Update(long accountId, long invoiceId, DataRequest_InvoidDetails data)
        {
            var query = _InvoiceDetailsServices.GetQueryable(record => record.ID == invoiceId);
            if (accountId > 0)
            {
                query = query.Where(record => record.Bill.AccountID == accountId);
            }
            if (query != null)
            {
                var item = query.FirstOrDefault();
                item.UnitPrice = data.UnitPrice;
                item.Price = data.Price;
                item.UnitPrice = data.UnitPrice;
                await _InvoiceDetailsServices.UpdateAsync(item);
                return new DataResponse_InvoiceDetail
                {
                    ProductID = item.ID,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Price = item.Price,
                    billId = item.BillID,
                };
            }
            throw new NotImplementedException(Common_Constants.ErrorExists.EmptyList);
        }
    }
}
