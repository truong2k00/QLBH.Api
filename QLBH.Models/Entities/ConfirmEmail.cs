using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class ConfirmEmail : DeleteEntity
    {
        public string CodeiVerification { get; set; }
        public DateTime Expired { get; set; }
        public bool IsConfirmed { get; set; }
        public long AccountID { get; set; }
        public virtual Account Account { get; set; }
        public long? Address_ReceiveID { get; set; }
        public virtual Address_Receive Address_Receive { get; set; }
        public long MailSettingID { get; set; }
        public virtual MailSetting MailSetting { get; set; }
    }
}
