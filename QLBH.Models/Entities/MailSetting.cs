using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models.Entities
{
    public class MailSetting : DeleteEntity
    {
        public EmailCode Code { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ConfirmEmail> ConfirmEmail { get; set;}
    }
}
