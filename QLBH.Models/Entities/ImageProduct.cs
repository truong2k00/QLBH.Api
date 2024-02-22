using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class ImageProduct : BaseEntity
    {
        public string Image_Url { get; set; }
        public long ProductID { get; set;}
        public virtual Product Product { get; set;}
    }
}
