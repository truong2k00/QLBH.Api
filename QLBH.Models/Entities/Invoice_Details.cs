using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class Invoice_Details : DeleteEntity
    {
        public long ProductID { get; set; }
        public virtual Product Product { get; set; }
        public long Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public long BillID {  get; set; }
        public virtual Bill Bill {  get; set; }
    }
}
