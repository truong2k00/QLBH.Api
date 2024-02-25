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
    public interface ICommentProduct<TEntity> : IReponsitory<DataRequest_CommentProduct, long>
    {
        Task Create(TEntity entity, RequestFiles File);
        Task Delete(long accountId, long id);
        PageResult<DataRespon_CommentProduct> GetAll(Pagination pagination,long accountId = 0, long productId = 0, string KeyWord = null);
    }
}
