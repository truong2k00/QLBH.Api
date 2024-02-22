using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataResponse_DetailCart : DataRequest_DetailCart
    {
        public long CartID { get; set; }
        public new long Quantity { get; set; }
        public long Price { get; set; }
        public decimal Cash { get; set; }
        public IEnumerable<DataResponse_Product> DataResponse_Product { get; set; }
    }
}
