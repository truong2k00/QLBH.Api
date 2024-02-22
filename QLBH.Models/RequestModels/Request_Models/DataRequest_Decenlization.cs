using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models
{
    public class DataRequest_Decenlization
    {
        public long AccountID { get; set; }
        public RoleType role { get; set; }
    }
}
