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
        public EmailCode Code { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
