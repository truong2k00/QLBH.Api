using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models
{
    public class Response_Feedback
    {
        public string feedBack_Quality { get; set; }
        public string opinion { get; set; }
        public Star star { get; set; }
    }
}
