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
using QLBH.Commons;

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

        public async Task Create(DataRequest_ProductCategory data)
        {
            try
            {
                var Entity = new ProductCategory
                {
                    CategoryName = data.categoryName,
                    Image = await _handleUpload.UploadImage(_contextAccessor.HttpContext.User.FindFirst(Clames.USER).Value, CloudUpoad.FolderImage.Folder_Category, data.files)
                };
                await _repository.CreateAsync(Entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Delete(long ID)
        {
            try
            {
                var Data = await _repository.GetByIDAsync(ID);
                Data.Deleted = true;
                await _repository.UpdateAsync(Data);
            }
            catch
            {
            }
        }

        public IEnumerable<DataResponse_ProductCategory> GetAll()
        {
            var query = _repository.GetQueryable();
            return query.Select(item => new DataResponse_ProductCategory
            {
                categoryName = item.CategoryName,
                productCategoryID = item.ID,
                image = item.Image,
            });
        }

        public async Task Update(long ID, DataRequest_ProductCategory data)
        {
            await Delete(ID);
            await Create(data);
        }
    }
}
