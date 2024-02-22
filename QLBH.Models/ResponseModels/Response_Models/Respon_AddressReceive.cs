using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class Respon_AddressReceive : Request_AddressReceive
    {
        public long addressID { get; set; }
    }
}
