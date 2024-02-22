using QLBH.Commons;
using QLBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Common_Constants;
using static QLBH.Commons.Enums;

namespace QLBH.Commons
{
    public class MailSeeding
    {
        public static List<ConfirmEmail> NewConfirmEmail(MailSetting mailSetting, long? accountId)
        {
            Random rand = new Random();
            var ListConfirm = new List<ConfirmEmail>();
            var Item = new ConfirmEmail();
            Item.CodeiVerification = (rand.Next(000000, 999999)).ToString();
            Item.Expired = DateTime.Now.AddMinutes(10);
            Item.IsConfirmed = false;
            Item.MailSetting = mailSetting;
            if (accountId.HasValue)
            {
                Item.AccountID = accountId.Value;
            }
            ListConfirm.Add(Item);
            return ListConfirm;
        }
    }
}
