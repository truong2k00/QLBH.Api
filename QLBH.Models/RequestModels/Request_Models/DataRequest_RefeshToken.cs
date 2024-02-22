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
        public string token { get; set; }
        public DateTime dateExpired { get; set; }
        public long accountID { get; set; }
    }
}
