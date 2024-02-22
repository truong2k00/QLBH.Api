using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IReponsitory<TEntity, Bind>
    {
        Task Create(TEntity data);
        Task Update(Bind iD,TEntity data);
        Task Delete(Bind iD);
    }
}
