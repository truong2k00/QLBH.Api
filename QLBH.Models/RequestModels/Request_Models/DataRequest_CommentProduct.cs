using QLBH.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models
{
    public class DataRequest_CommentProduct
    {
        public long AccountID { get; set; }
        public long ProductID { get; set; }
        public string Opinion { get; set; }
    }
}
