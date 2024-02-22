using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_RefeshToken
    {
        public string Token { get; set; }
        public DateTime Date_Expired { get; set; }
        public long AccountID { get; set; }
    }
}
