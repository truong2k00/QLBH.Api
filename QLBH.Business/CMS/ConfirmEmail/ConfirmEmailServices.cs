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
                CodeiVerification = record.CodeiVerification,
                Expired = record.Expired,
                IsConfirmed = record.IsConfirmed,
                UserName = record.Account.User_Name,
                MailSettingID = record.MailSetting.ID
            });
        }
        public async Task<DataResponCode> ConfirmEmail(string AccountName,int code)
        {
            var Confirm = (await _baseRepositoryConfirm.GetAllAsync(record => record.Account.User_Name == AccountName && record.IsConfirmed == false && record.Expired >= DateTime.Now && record.Deleted == false)).Last();
            if (Confirm == null) return new DataResponCode { Status = StatusCodes.Status404NotFound, Message = CodeVerification.Message_404_code };
            else
            {
                if (Confirm.CodeiVerification == code.ToString())
                {
                    Confirm.Deleted = true;
                    Confirm.IsConfirmed = true;
                    await _baseRepositoryConfirm.UpdateAsync(Confirm);
                    return new DataResponCode
                    {
                        Status = StatusCodes.Status200OK,
                        Message = SUCCESS
                    };
                }
                else
                {
                    return new DataResponCode
                    {
                        Status = StatusCodes.Status408RequestTimeout,
                        Message = CodeVerification.Message_408_code
                    };
                }
            }
        }
    }
}
