using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class Status_Bill : DeleteEntity
    {
        public string Status_Name { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
    }
}
