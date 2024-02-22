using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_Notification
    {
        public string notificationTitle { get; set; }
        public string notificationDescription { get; set; }
        public long accountID { get; set; }
    }
}
