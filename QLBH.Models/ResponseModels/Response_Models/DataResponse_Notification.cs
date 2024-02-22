using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataResponse_Notification : DataRequest_Notification
    {
        public bool watched_at { get; set; }
        public long notificationId { get; set; }
    }
}
