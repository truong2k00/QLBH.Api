using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models.Entities
{
    public class FeedBack : BaseEntity
    {
        public string FeedBack_Quality { get; set; }
        public string Opinion { get; set; }
        public Star star { get; set; }
        public long AccountID { get; set; }
        public virtual Account Account { get; set; }
        public long ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
