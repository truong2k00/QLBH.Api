using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Services.Identity;
using QLBH.Commons;

namespace QLBH.Business
{
    public class DetailProductServices : IDetailProductServices
    {
        private readonly IBaseRepository<Details> _DetailRepository;
        private readonly IBaseRepository<Product> _productRepository;

        public DetailProductServices(IBaseRepository<Details> detailRepository
            , IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _DetailRepository = detailRepository;
        }

        public Task<DataResponse_DetailProduct> Create(DataRequest_DetailProduct data)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse_DetailProduct> CreateAsync(long accountId, DataRequest_DetailProduct data)
        {
            var query = _productRepository.GetQueryable(record => record.AccountID == accountId && record.ID == data.ProductID);
            if (!query.Any())
            {
                throw new NotImplementedException(Common_Constants.ErrorExists.EmptyList);
            }
            if (_DetailRepository.GetQueryable(record => record.ProductID == data.ProductID).Any())
            {
                throw new NotImplementedException(Common_Constants.ErrorExists.AlreadyExist);
            }
            var item = new Details
            {
                Detail_Introduce = data.Introduce,
                Introduce = data.Introduce,
                ProductID = data.ProductID,
            };
            await _DetailRepository.CreateAsync(item);
            return new DataResponse_DetailProduct
            {
                Detail_Introduce = item.Detail_Introduce,
                Introduce = item.Introduce,
                ProductID = item.ProductID
            };
        }

        public async Task<bool> Delete(long ID)
        {
            return await _DetailRepository.DeleteAsync(ID);
        }

        public async Task<DataResponse_DetailProduct> Update(long accountId, DataRequest_DetailProduct data)
        {
            var item = await _DetailRepository.GetAsync(record => record.ProductID == data.ProductID);
            item.Detail_Introduce = data.Detail_Introduce;
            item.Introduce = data.Introduce;
            await _DetailRepository.UpdateAsync(item);
            return new DataResponse_DetailProduct
            {
                Detail_Introduce = item.Detail_Introduce,
                Introduce = item.Introduce,
                ProductID = item.ProductID
            };
        }
    }
}
