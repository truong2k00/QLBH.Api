using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class RefeshToken : DeleteEntity
    {
        public string Token { get; set; }
        public DateTime Date_Expired { get; set; }
        public long AccountID { get; set; }
        public virtual Account Account { get; set; }
    }
}
