using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class Cart : BaseEntity
    {
        public long AccountID { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Detail_Cart> Detail_Cart { get; set; }
    }
}
