using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IReponsitory<TEntity,REntity, Bind>
    {
        Task<REntity> Create(TEntity data);
        Task<REntity> Update(Bind ID,TEntity data);
        Task<bool> Delete(Bind ID);
    }
}
