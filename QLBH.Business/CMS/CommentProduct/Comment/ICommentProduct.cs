using QLBH.Commons.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Commons.Common_Page;
using QLBH.Models;

namespace QLBH.Business
{
    public interface ICommentProduct<TEntity> : IReponsitory<DataRequest_CommentProduct, DataRespon_CommentProduct, long>
    {
        Task<ResponcesObject<DataRespon_CommentProduct>> CreateAsync(TEntity entity, RequestFiles File);
        Task<bool> DeleteAsync(long accountId, long id);
        PageResult<DataRespon_CommentProduct> GetAll(Pagination pagination, string KeyWord);
        PageResult<DataRespon_CommentProduct> GetAll(long productId, long accountId, Pagination pagination, string KeyWord);
    }
}
