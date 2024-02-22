using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataResponse_Bill
    {
        public long BillId { get; set; }
        public DateTime Date_Create { get; set; }
        public long Status_BillID { get; set; }
        public long AccountID { get; set; }
        public decimal TotalPrice { get; set; }
        public long Address_ReceiveID { get; set; }
        public IEnumerable<DataResponse_InvoiceDetail> InvoiceDetail { get; set; }
    }
}
