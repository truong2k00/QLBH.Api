using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRespon_ImageComment : Request_ImageComment
    {
        public long ImageCommentID { get; set; }
        public string href { get; set; }
    }
}
