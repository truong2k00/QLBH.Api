using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataResponse_DetailCart : DataRequest_DetailCart
    {
        public long cartID { get; set; }
        public new long quantity { get; set; }
        public long price { get; set; }
        public decimal totalPrice { get; set; }
        public IEnumerable<DataResponse_Product> dataResponseProduct { get; set; }
    }
}
