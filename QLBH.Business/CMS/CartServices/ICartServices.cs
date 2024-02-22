using QLBH.Models;
using QLBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface ICartServices : IReponsitory<DataRequest_Cart,DataResponse_Cart,long>
    {
        Task<IEnumerable<Cart>> GetAllCart();
    }
}
