using QLBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_InvoiceDetails
    {
        public long productID { get; set; }
        public long quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal price { get; set; }
    }
}
