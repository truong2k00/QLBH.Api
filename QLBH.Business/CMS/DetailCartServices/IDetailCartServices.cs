using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IDetailCartServices : IReponsitory<DataRequest_DetailCart, long>
    {
        Task AddCart(long idUser, string meta);
<<<<<<< Updated upstream
        IEnumerable<DataResponse_DetailCart> GetByAccount(long idUser);
=======
        Task<IEnumerable<DataResponse_DetailCart>> GetByAccount(long idUser);
>>>>>>> Stashed changes
    }
}
