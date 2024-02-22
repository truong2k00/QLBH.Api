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

        public async Task<DataResponse_Bill> Create(DataRequest_Bill item)
        {
            var entity = new Bill
            {
                Status_BillID = 1,
                AccountID = item.AccountID,
                Address_ReceiveID = item.Address_ReceiveID,
            };
            await _billRepository.CreateAsync(entity);
            if (item.invoiceDetail.Any())
            {
                entity.Invoice_Details = new List<Invoice_Details>();
                foreach (var data in item.invoiceDetail)
                {
                    entity.Invoice_Details.Add(new Invoice_Details
                    {
                        ProductID = data.ProductID,
                        Quantity = data.Quantity,
                        UnitPrice = data.UnitPrice,
                        Price = data.Price,
                    });
                }
                await _billRepository.UpdateAsync(entity);
            }
            var bill = _billRepository.GetQueryable(record => record.ID == entity.ID);
            var Data = bill.Select(item => new DataResponse_Bill
            {
                BillId = item.ID,
                Date_Create = item.Date_Create,
                Status_BillID = item.Status_BillID,
                AccountID = item.AccountID,
                TotalPrice = item.TotalPrice,
                Address_ReceiveID = item.Address_ReceiveID,
                InvoiceDetail = _invoiceServices.GetAll(item.ID).ToList(),
            }).FirstOrDefault();
            return Data;
        }

        public async Task<bool> Delete(long ID)
        {
            try
            {
                var item = await _billRepository.GetByIDAsync(ID);
                await _invoiceServices.DeleteAsync(item.ID);
                item.Deleted = true;
                await _billRepository.UpdateAsync(item);
                return true;
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
                BillId = Data.ID,
                Date_Create = Data.Date_Create,
                Status_BillID = Data.Status_BillID,
                AccountID = Data.AccountID,
                Address_ReceiveID = Data.Address_ReceiveID,
                TotalPrice = Data.TotalPrice,
                InvoiceDetail = _invoiceServices.GetAll(Data.ID).ToList()
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
                BillId = item.ID,
                Date_Create = item.Date_Create,
                Status_BillID = item.Status_BillID,
                AccountID = item.AccountID,
                Address_ReceiveID = item.Address_ReceiveID,
                TotalPrice = item.TotalPrice,
                InvoiceDetail = _invoiceServices.GetAll(item.ID)
            }).AsEnumerable();
            return result;
        }

        public async Task<DataResponse_Bill> Update(long ID)
        {
            var items = await _billRepository.GetAsync(record => record.ID == ID && record.Deleted == false && record.Status_BillID > 1);
            if (items != null)
            {
                var data = _invoiceServices.GetAll(items.ID);
                decimal totalPrice = 0;
                foreach (var item in data)
                {
                    totalPrice += item.Price;
                }
                items.TotalPrice = totalPrice;
                await _billRepository.UpdateAsync(items);
                return new DataResponse_Bill
                {
                    BillId = items.ID,
                    Date_Create = items.Date_Create,
                    Status_BillID = items.Status_BillID,
                    AccountID = items.AccountID,
                    TotalPrice = items.TotalPrice,
                    Address_ReceiveID = items.Address_ReceiveID,
                    InvoiceDetail = _invoiceServices.GetAll(items.ID).ToList(),
                };
            }
            throw new Exception(Common_Constants.ErrorExists.EmptyList);
        }

        public async Task<DataResponse_Bill> DeleteInvoice(long invoiceId)
        {
            var entity = await _invoiceServices.GetByID(invoiceId);
            var billId = entity.BillID;
            if (await _invoiceServices.Delete(entity.ID))
            {
                return await Update(billId);
            }
            throw new Exception(Common_Constants.ErrorExists.EmptyList);
        }
    }
}