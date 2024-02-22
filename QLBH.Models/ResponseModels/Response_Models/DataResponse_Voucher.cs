using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataResponse_Voucher
    {
        public long voucherID { get; set; }
        public string voucher { get; set; }
        public string voucherName { get; set; }
        public DateTime releaseDate { get; set; }
        public DateTime expirationDate { get; set; }
        public long quantity { get; set; }
        public decimal reducted_Value { get; set; }
        public long accountID { get; set; }
        public string userName { get; set; }
        public bool work { get; set; }
    }
}
