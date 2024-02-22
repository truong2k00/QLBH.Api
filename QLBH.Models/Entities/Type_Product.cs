using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class Type_Product : BaseEntity
    {
        public string Type_Name { get; set; }
        public string Image {  get; set; }
        public long ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
