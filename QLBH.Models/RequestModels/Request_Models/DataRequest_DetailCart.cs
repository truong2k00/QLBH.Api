using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_DetailCart
    {
        public long AccountID { get; set; }
        public long ProductID { get; set; }
        public long Quantity { get; set; }
    }
}
