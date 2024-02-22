using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_Voucher
    {
        public string VoucherName { get; set; }
        public int Expiration_Date { get; set; }
        public long Quantity { get; set; }
        public decimal Reducted_Value { get; set; }
        public long AccountID { get; set; }

    }
}
