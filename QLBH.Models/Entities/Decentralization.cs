using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models.Entities
{
    public class Decentralization : DeleteEntity
    {
        public long AccountID { get; set; }
        public virtual Account Account { get; set; }
        public RoleType role { get; set; }
        public long RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
