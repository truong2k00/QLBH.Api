using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_DetailCart
    {
        public long accountID { get; set; }
        public long productID { get; set; }
        public long quantity { get; set; }
    }
}
