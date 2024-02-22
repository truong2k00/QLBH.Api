using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_Voucher
    {
        public string voucherName { get; set; }
        public int expirationDate { get; set; }
        public long quantity { get; set; }
        public decimal reductedValue { get; set; }
        public long accountID { get; set; }

    }
}
