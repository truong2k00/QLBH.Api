using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Services.Identity;
using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Common_Constants;
using static QLBH.Commons.ImageHepper;

namespace QLBH.Business
{
    public class TypeProductServices : ITypeProductServices
    {
        private readonly IBaseRepository<Type_Product> _repository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UploadImages _handleUpload;

        public TypeProductServices(IBaseRepository<Type_Product> repository, IHttpContextAccessor contextAccessor, UploadImages handleUpload)
        {
            _repository = repository;
            _contextAccessor = contextAccessor;
            _handleUpload = handleUpload;
        }

        public async Task<DataResponse_TypeProduct> Create(DataRequest_TypeProduct data)
        {
            var Entity = new Type_Product
            {
                Type_Name = data.Type_Name,
                ProductID = data.ProductID,
                Image = await _handleUpload.UploadImage(_contextAccessor.HttpContext.User.FindFirst(Clames.USER).Value, data.Image)
            };
            await _repository.CreateAsync(Entity);
            return new DataResponse_TypeProduct
            {
                ID = Entity.ID,
                Image = Entity.Image,
                ProductID = Entity.ProductID,
                Type_Name = Entity.Type_Name,
            };
        }

        public async Task<bool> Delete(long ID)
        {
            return await _repository.DeleteAsync(ID);
        }

        public async Task<IEnumerable<DataResponse_TypeProduct>> GetAll()
        {
            var Data = await _repository.GetAllAsync();
            return Data.Select(item => new DataResponse_TypeProduct
            {
                ID = item.ID,
                Image = item.Image,
                ProductID = item.ProductID,
                Type_Name = item.Type_Name,
            });
        }

        public async Task<IEnumerable<DataResponse_TypeProduct>> GetByIDProduct(long IDProduct)
        {
            var Data = await _repository.GetAllAsync(record => record.ProductID == IDProduct);
            return Data.Select(item => new DataResponse_TypeProduct
            {
                ID = item.ID,
                Image = item.Image,
                ProductID = item.ProductID,
                Type_Name = item.Type_Name,
            });
        }

        public async Task<DataResponse_TypeProduct> Update(long ID, DataRequest_TypeProduct data)
        {
            if (await Delete(ID))
            {
                return await Create(data);
            }
            return null;
        }
    }
}
