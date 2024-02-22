using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_Bill
    {
        public long status_BillID { get; set; }
        public long accountID { get; set; }
        public List<DataRequest_InvoidDetails> invoiceDetail { get; set; }
        public long address_ReceiveID { get; set; }
    }
}
