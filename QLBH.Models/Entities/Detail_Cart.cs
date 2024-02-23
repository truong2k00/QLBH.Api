using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class Detail_Cart : BaseEntity
    {
        public long CartID { get; set; }
        public virtual Cart Cart { get; set; }
        public long ProductID { get; set; }
        public virtual Product Product { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
