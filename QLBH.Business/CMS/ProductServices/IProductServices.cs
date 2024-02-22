using QLBH.Commons.Common_Page;
using QLBH.Models;

namespace QLBH.Business
{
    public interface IProductServices<TEntity, Base>
    {
        Task Create(Request_Product item, RequestFiles file);
        Task Update(long IDProduct, Request_Product item, RequestFiles file);
        PageResult<TEntity> GetAll(Pagination pagination, string KeyWord);
        IEnumerable<TEntity> GetAllSale();
        Task<TEntity> GetByID(Base ID);
        PageResult<TEntity> GetByAccount(Pagination pagination, string KeyWord, long IDAccount);
        PageResult<TEntity> GetByCategory(Pagination pagination, string KeyWord, long IDCategory);
        IEnumerable<TEntity> GetByMeta(string meta);
        Task Delete(long ID);
    }
}
