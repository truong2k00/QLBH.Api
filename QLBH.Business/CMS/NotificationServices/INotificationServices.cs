using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface INotificationServices : IReponsitory<DataRequest_Notification, long>
    {
        Task<IEnumerable<DataResponse_Notification>> GetAll();
        Task<DataResponse_Notification> Watched(long id);
        Task<IEnumerable<DataResponse_Notification>> GetByAccount(long AccountID);
    }
}
