using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class Notification : BaseEntity
    {
        public string Notification_Title { get; set; }
        public string Notification_Description { get; set; }
        public bool watched_at { get; set; }
        public long AccountID { get; set; }
        public virtual Account Account { get; set; }
    }
}
