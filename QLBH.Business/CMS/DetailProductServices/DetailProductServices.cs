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
            try
            {
                var query = _productRepository.GetQueryable(record => record.AccountID == accountId && record.ID == data.productID);
                var queryDetails = _detailRepository.GetQueryable(record => record.ProductID == data.productID);
                if (query.Any() && !queryDetails.Any())
                {
                    var item = new Details
                    {
                        Detail_Introduce = data.detail_Introduce,
                        Introduce = data.introduce,
                        ProductID = data.productID,
                    };
                    await _detailRepository.CreateAsync(item);
                }
                Console.WriteLine($"Error: ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }

        public Task Delete(long iD)
        {
            throw null;
        }
        public async Task Delete(long accountID, long iD)
        {
            try
            {
                var entity = await _detailRepository.GetAsync(record => record.ID == iD && record.Product.AccountID == accountID);
                await _detailRepository.DeleteAsync(entity.ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }

        public async Task Update(long accountId, DataRequest_DetailProduct data)
        {
            try
            {
                var item = await _detailRepository.GetAsync(record => record.ProductID == data.productID);
                item.Detail_Introduce = data.detail_Introduce;
                item.Introduce = data.introduce;
                await _detailRepository.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }
    }
}
