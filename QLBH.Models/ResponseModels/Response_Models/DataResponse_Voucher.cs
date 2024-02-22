using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataResponse_Voucher
    {
        public long ID { get; set; }
        public string VoucherId { get; set; }
        public string VoucherName { get; set; }
        public DateTime Release_Date { get; set; }
        public DateTime Expiration_Date { get; set; }
        public long Quantity { get; set; }
        public decimal Reducted_Value { get; set; }
        public long AccountID { get; set; }
        public string UserName { get; set; }
        public bool Work { get; set; }
    }
}
