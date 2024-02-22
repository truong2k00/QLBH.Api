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
        private readonly IBaseRepository<Details> _detailRepository;
        private readonly IBaseRepository<Product> _productRepository;

        public DetailProductServices(IBaseRepository<Details> detailRepository
            , IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _detailRepository = detailRepository;
        }

        public Task Create(DataRequest_DetailProduct data)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(long accountId, DataRequest_DetailProduct data)
        {
            var query = _productRepository.GetQueryable(record => record.AccountID == accountId && record.ID == data.productID);
            if (!query.Any())
            {
                throw new NotImplementedException(Common_Constants.ErrorExists.EmptyList);
            }
            if (_detailRepository.GetQueryable(record => record.ProductID == data.productID).Any())
            {
                throw new NotImplementedException(Common_Constants.ErrorExists.AlreadyExist);
            }
            var item = new Details
            {
                Detail_Introduce = data.detail_Introduce,
                Introduce = data.introduce,
                ProductID = data.productID,
            };
            await _detailRepository.CreateAsync(item);
        }

        public async Task Delete(long iD)
        {
            await _detailRepository.DeleteAsync(iD);
        }

        public async Task Update(long accountId, DataRequest_DetailProduct data)
        {
            var item = await _detailRepository.GetAsync(record => record.ProductID == data.productID);
            item.Detail_Introduce = data.detail_Introduce;
            item.Introduce = data.introduce;
            await _detailRepository.UpdateAsync(item);
        }
    }
}
