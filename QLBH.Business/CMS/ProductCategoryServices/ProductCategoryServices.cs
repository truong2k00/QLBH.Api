using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Services.Identity;
using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static QLBH.Commons.ImageHepper;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Business.CMS
{
    public class ProductCategoryServices : IProductCategoryServices
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IBaseRepository<ProductCategory> _repository;
        private readonly UploadImages _handleUpload;

        public ProductCategoryServices(IBaseRepository<ProductCategory> repository
            , UploadImages handleUpload
            , IHttpContextAccessor contextAccessor)
        {
            _repository = repository;
            _handleUpload = handleUpload;
            _contextAccessor = contextAccessor;
        }

        public async Task<DataResponse_ProductCategory> Create(DataRequest_ProductCategory data)
        {
            var Entity = new ProductCategory
            {
                CategoryName = data.CategoryName,
                Image = await _handleUpload.UploadImage(_contextAccessor.HttpContext.User.FindFirst(Clames.USER).Value, data.Files)
            };
            await _repository.CreateAsync(Entity);
            return new DataResponse_ProductCategory
            {
                CategoryName = Entity.CategoryName,
                ID = Entity.ID,
                Image = Entity.Image,
            };
        }
        public async Task<bool> Delete(long ID)
        {
            try
            {
                var Data = await _repository.GetByIDAsync(ID);
                Data.Deleted = true;
                await _repository.UpdateAsync(Data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<DataResponse_ProductCategory>> GetAll()
        {
            var Datas = await _repository.GetAllAsync();
            return Datas.Select(item => new DataResponse_ProductCategory
            {
                CategoryName = item.CategoryName,
                ID = item.ID,
                Image = item.Image,
            });
        }

        public async Task<DataResponse_ProductCategory> Update(long ID, DataRequest_ProductCategory data)
        {
            await Delete(ID);
            return await Create(data);
        }
    }
}
