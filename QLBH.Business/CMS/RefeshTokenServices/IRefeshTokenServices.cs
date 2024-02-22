using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IRefeshTokenServices
    {
        Task<IEnumerable<DataResponse_RefeshToken>> GetAll();
        Task<IEnumerable<DataResponse_RefeshToken>> GetAll(long AccountID);
    }
}
