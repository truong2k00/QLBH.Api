using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_Notification
    {
        public string Notification_Title { get; set; }
        public string Notification_Description { get; set; }
        public long AccountID { get; set; }
    }
}
