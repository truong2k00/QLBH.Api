using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Common_Constants;
using Microsoft.AspNetCore.Http;

namespace QLBH.Business
{
    public class ConfirmEmailServices : IConfirmEmail
    {
        private readonly IBaseRepository<ConfirmEmail> _baseRepositoryConfirm;

        public ConfirmEmailServices(IBaseRepository<ConfirmEmail> baseRepositoryConfirm)
        {
            _baseRepositoryConfirm = baseRepositoryConfirm;
        }

        public IEnumerable<Response_ConfirmEmail> GetAll(long accountID)
        {
            var query = _baseRepositoryConfirm.GetQueryable(record => record.AccountID == accountID);
            return query.Select(record => new Response_ConfirmEmail
            {
                codeiVerification = record.CodeiVerification,
                expired = record.Expired,
                isConfirmed = record.IsConfirmed,
                userName = record.Account.User_Name,
                mailSettingID = record.MailSetting.ID
            });
        }
        public async Task<DataResponCode> ConfirmEmail(string AccountName, int code)
        {
            var Confirm = (await _baseRepositoryConfirm.GetAllAsync(record => record.Account.User_Name == AccountName && record.IsConfirmed == false && record.Expired >= DateTime.Now && record.Deleted == false)).Last();
            if (Confirm == null) return new DataResponCode { status = StatusCodes.Status404NotFound, message = CodeVerification.Message_404_code };
            else
            {
                if (Confirm.CodeiVerification == code.ToString())
                {
                    Confirm.Deleted = true;
                    Confirm.IsConfirmed = true;
                    await _baseRepositoryConfirm.UpdateAsync(Confirm);
                    return new DataResponCode
                    {
                        status = StatusCodes.Status200OK,
                        message = SUCCESS
                    };
                }
                else
                {
                    return new DataResponCode
                    {
                        status = StatusCodes.Status408RequestTimeout,
                        message = CodeVerification.Message_408_code
                    };
                }
            }
        }
    }
}
