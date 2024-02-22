using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class ProductCategory : DeleteEntity
    {
        public string CategoryName { get; set;}
        public string Image { get; set;}
        public virtual ICollection<Product> Product {  get; set; }
    }
}
