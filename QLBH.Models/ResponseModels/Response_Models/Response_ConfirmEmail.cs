using QLBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Models
{
    public class Response_ConfirmEmail
    {
        public string codeiVerification { get; set; }
        public DateTime expired { get; set; }
        public bool isConfirmed { get; set; }
        public string userName { get; set; }
        public long mailSettingID { get; set; }
    }
}
