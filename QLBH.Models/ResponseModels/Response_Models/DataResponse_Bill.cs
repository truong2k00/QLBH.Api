using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataResponse_Bill
    {
        public long billId { get; set; }
        public DateTime date_Create { get; set; }
        public long statusBillID { get; set; }
        public long accountID { get; set; }
        public decimal totalPrice { get; set; }
        public long addressReceiveID { get; set; }
        public IEnumerable<DataResponse_InvoiceDetail> invoiceDetail { get; set; }
    }
}
