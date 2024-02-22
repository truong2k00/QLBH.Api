using QLBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataResponse_Decenlization
    {
        public long accountID { get; set; }
        public string user { get; set; }
        public List<string> roles { get; set; }
    }
}
