using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models
{
    public class DataRequest_MailSetting
    {
        public EmailCode code { get; set; }
        public string tieuDe { get; set; }
        public string noiDung { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
