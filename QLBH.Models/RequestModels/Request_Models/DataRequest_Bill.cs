using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_Bill
    {
        public long Status_BillID { get; set; }
        public long AccountID { get; set; }
        public List<DataRequest_InvoidDetails> invoiceDetail { get; set; }
        public long Address_ReceiveID { get; set; }
    }
}
