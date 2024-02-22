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
        public string CodeiVerification { get; set; }
        public DateTime Expired { get; set; }
        public bool IsConfirmed { get; set; }
        public string UserName { get; set; }
        public long MailSettingID { get; set; }
    }
}
