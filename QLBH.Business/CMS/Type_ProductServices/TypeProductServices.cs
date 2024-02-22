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

        public async Task Create(DataRequest_TypeProduct data)
        {
            var Entity = new Type_Product
            {
                Type_Name = data.type_Name,
                ProductID = data.productID,
                Image = await _handleUpload.UploadImage(_contextAccessor.HttpContext.User.FindFirst(Clames.USER).Value, data.image)
            };
            await _repository.CreateAsync(Entity);
        }

        public async Task Delete(long ID)
        {
            await _repository.DeleteAsync(ID);
        }

        public IEnumerable<DataResponse_TypeProduct> GetAll()
        {
            return GetAll(0);
        }

        public IEnumerable<DataResponse_TypeProduct> GetAll(long productId = 0)
        {
            var query = _repository.GetQueryable();
            if (productId != 0)
            {
                query = query.Where(record => record.ProductID == productId);
            }
            return query.Select(item => new DataResponse_TypeProduct
            {
                iD = item.ID,
                image = item.Image,
                productID = item.ProductID,
                typeName = item.Type_Name,
            });
        }

        public async Task Update(long ID, DataRequest_TypeProduct data)
        {
            await Create(data);
        }
    }
}
