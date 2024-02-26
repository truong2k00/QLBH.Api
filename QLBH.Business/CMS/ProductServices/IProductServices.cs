using QLBH.Commons.Common_Page;
using QLBH.Models;

namespace QLBH.Business
{
    public interface IProductServices<TEntity, Base>
    {
        Task Create(Request_Product item, RequestFiles file);
        Task Update(long productID, Request_Product item, RequestFiles file);
        PageResult<TEntity> GetAll(Pagination pagination, string keyWord, long accountID = 0, long categoryID = 0, bool sale = false);
        IEnumerable<TEntity> GetByMeta(string meta);
        Task Delete(long id);
    }
}
