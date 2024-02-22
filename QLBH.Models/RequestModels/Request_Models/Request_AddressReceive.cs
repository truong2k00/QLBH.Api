using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class Request_AddressReceive
    {
        public long AccountID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Full_Name { get; set; }
        public string Describe { get; set; }
        public string Email { get; set; }
    }
}
