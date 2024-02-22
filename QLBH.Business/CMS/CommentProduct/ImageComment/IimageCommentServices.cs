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
        Task<bool> Delete(Bind ID);
        Task<IEnumerable<TEntity>> Update(string Username, Bind ID, RequestFiles files);
        Task<TEntity> GetById(Bind id);
    }
}
