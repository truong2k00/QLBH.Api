﻿using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IMailSettingServices : IReponsitory<DataRequest_MailSetting, DataResponse_MailSetting, long>
    {
        Task<IEnumerable<DataResponse_MailSetting>> GetAllMail();
    }
}