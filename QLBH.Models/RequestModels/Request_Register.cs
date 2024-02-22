using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class Request_Register
    {
        public string fullName { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string newPassword { get; set; }
        public string phone_Number { get; set; }
        public string email { get; set; }
    }
}
