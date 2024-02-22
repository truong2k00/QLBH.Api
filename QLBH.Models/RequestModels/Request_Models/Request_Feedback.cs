using QLBH.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models
{
    public class Request_Feedback
    {
        public long accountID { get; set; }
        public long productID { get; set; }
        public string feedBackQuality { get; set; }
        public string opinion { get; set; }
        public Star star { get; set; }
    }
}
