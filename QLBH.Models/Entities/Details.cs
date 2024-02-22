using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class Details : BaseEntity
    {
        public string Introduce { get; set; }
        public string Detail_Introduce { get; set; }
        public long ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
