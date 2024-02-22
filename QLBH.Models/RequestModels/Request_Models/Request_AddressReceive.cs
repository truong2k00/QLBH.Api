using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class Request_AddressReceive
    {
        public long accountID { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string full_Name { get; set; }
        public string describe { get; set; }
        public string email { get; set; }
    }
}
