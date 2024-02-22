using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class Bill : DeleteEntity
    {
        public DateTime Date_Create { get; set; } = DateTime.Now;
        public long Status_BillID { get; set; }
        public virtual Status_Bill Status_Bill { get; set; }
        public long AccountID { get; set; }
        public virtual Account Account { get; set; }
        public long Address_ReceiveID { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Address_Receive Address_Receive { get; set; }
        public ICollection<Invoice_Details> Invoice_Details { get; set; }
    }
}
