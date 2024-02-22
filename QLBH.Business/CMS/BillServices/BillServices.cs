﻿using Microsoft.Identity.Client;
using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Commons;
using Microsoft.VisualStudio.Services.CircuitBreaker;
using Org.BouncyCastle.Math.Field;

namespace QLBH.Business
{
    public class BillServices : IBillServices
    {
        private readonly IBaseRepository<Bill> _billRepository;
        private readonly IInvoiceDetailsServices _invoiceServices;

        public BillServices(IBaseRepository<Bill> billRepository, IInvoiceDetailsServices invoiceServices)
        {
            _billRepository = billRepository;
            _invoiceServices = invoiceServices;
        }

        public async Task Create(DataRequest_Bill item)
        {
            var entity = new Bill
            {
                Status_BillID = 1,
                AccountID = item.accountID,
                Address_ReceiveID = item.addressReceiveID,
            };
            await _billRepository.CreateAsync(entity);
            if (item.invoiceDetail.Any())
            {
                entity.Invoice_Details = new List<Invoice_Details>();
                foreach (var data in item.invoiceDetail)
                {
                    entity.Invoice_Details.Add(new Invoice_Details
                    {
                        ProductID = data.productID,
                        Quantity = data.quantity,
                        UnitPrice = data.unitPrice,
                        Price = data.price,
                    });
                }
                await _billRepository.UpdateAsync(entity);
            }
        }

        public async Task Delete(long ID)
        {
            try
            {
                var item = await _billRepository.GetByIDAsync(ID);
                await _invoiceServices.DeleteAsync(item.ID);
                item.Deleted = true;
                await _billRepository.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                throw new Exception(Common_Constants.ErrorExists.EmptyList, ex);
            }
        }
        public async Task<DataResponse_Bill> GetByIDAsync(long ID)
        {
            var Data = await _billRepository.GetAsync(record => record.ID == ID);
            return new DataResponse_Bill
            {
                billId = Data.ID,
                date_Create = Data.Date_Create,
                statusBillID = Data.Status_BillID,
                accountID = Data.AccountID,
                addressReceiveID = Data.Address_ReceiveID,
                totalPrice = Data.TotalPrice,
                invoiceDetail = _invoiceServices.GetAll(Data.ID).ToList()
            };
        }
        public IEnumerable<DataResponse_Bill> GetBillAsync()
        {
            return GetBillAsync(0, false);
        }
        public IEnumerable<DataResponse_Bill> GetBillAsync(bool IsDelete = true)
        {
            return GetBillAsync(0, IsDelete);
        }
        public IEnumerable<DataResponse_Bill> GetBillAsync(long accountId = 0, bool IsDelete = false)
        {
            var query = _billRepository.GetQueryable(record => record.Deleted == IsDelete);
            if (accountId > 0)
            {
                query = query.Where(record => record.AccountID == accountId);
            }
            var result = query.Select(item => new DataResponse_Bill
            {
                billId = item.ID,
                date_Create = item.Date_Create,
                statusBillID = item.Status_BillID,
                accountID = item.AccountID,
                addressReceiveID = item.Address_ReceiveID,
                totalPrice = item.TotalPrice,
                invoiceDetail = _invoiceServices.GetAll(item.ID)
            }).AsEnumerable();
            return result;
        }

        public async Task Update(long ID)
        {
            var items = await _billRepository.GetAsync(record => record.ID == ID && record.Deleted == false && record.Status_BillID > 1);
            if (items != null)
            {
                var data = _invoiceServices.GetAll(items.ID);
                decimal totalPrice = 0;
                foreach (var item in data)
                {
                    totalPrice += item.price;
                }
                items.TotalPrice = totalPrice;
                await _billRepository.UpdateAsync(items);
            }
            else { throw new Exception(Common_Constants.ErrorExists.EmptyList); }
        }

        public async Task DeleteInvoice(long invoiceId)
        {
            var entity = await _invoiceServices.GetByID(invoiceId);
            var billId = entity.BillID;
            try
            {
                await _invoiceServices.Delete(entity.ID);
                await Update(billId);
            }
            catch (Exception ex)
            {
                throw new Exception(Common_Constants.ErrorExists.EmptyList, ex);
            }
        }
    }
}
