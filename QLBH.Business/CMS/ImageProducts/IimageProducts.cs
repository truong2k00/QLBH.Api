using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IimageProducts<TEntity,Bind> : IReponsitory<Request_ImageProduct,Respon_ImageProduct,long>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Bind IDProduct);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIDAsync(Bind ID);
    }
}
