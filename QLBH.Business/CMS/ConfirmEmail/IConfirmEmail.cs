using Microsoft.AspNetCore.Http;
using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Business
{
    public interface IConfirmEmail
    {
        IEnumerable<Response_ConfirmEmail> GetAll(long accountID);
        Task<DataResponCode> ConfirmEmail(string AccountName, int code);
    }
}
