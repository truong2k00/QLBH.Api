using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IimageCommentServices<TEntity, Bind>
    {
        Task Delete(Bind id);
        Task Update(string Username, Bind id, RequestFiles files);
        Task<TEntity> GetById(Bind id);
        Task<object> GetById(object iDImage);
    }
}
