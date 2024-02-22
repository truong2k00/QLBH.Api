using Microsoft.AspNetCore.Http;
using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Repository;
using static QLBH.Commons.Enums;
using static QLBH.Commons.MailHepper;
using QLBH.Commons.Common_Page;
using QLBH.Commons;
using Microsoft.Identity.Client;

namespace QLBH.Business
{
    public class AddressReceiveServices : IAddressReceive<Respon_AddressReceive, long>
    {
        private readonly EmailSender _emailSender;
        private readonly IBaseRepository<Address_Receive> _baseRepositoryAddress;
        private readonly IBaseRepository<ConfirmEmail> _baseRepositoryConfirm;
        private readonly IBaseRepository<MailSetting> _baseRepositoryMailSetting;

        public AddressReceiveServices(IBaseRepository<Address_Receive> baseRepositoryAddress
            , EmailSender emailSender
            , IBaseRepository<MailSetting> baseRepositoryMailSetting
            , IBaseRepository<ConfirmEmail> baseRepositoryConfirm)
        {
            _emailSender = emailSender;
            _baseRepositoryConfirm = baseRepositoryConfirm;
            _baseRepositoryMailSetting = baseRepositoryMailSetting;
            _baseRepositoryAddress = baseRepositoryAddress;
        }
        //create Address receive
        public async Task<Respon_AddressReceive> Create(Request_AddressReceive item)
        {
            Address_Receive address = new Address_Receive
            {
                AccountID = item.accountID,
                Address = item.address,
                Phone = item.phone,
                Full_Name = item.fullName,
                Describe = item.describe,
                Email = item.email,
            };
            MailSetting mailsetting = await _baseRepositoryMailSetting.GetAsync(x => x.Code == EmailCode.XacThucEmail);
            address.ConfirmEmail = MailSeeding.NewConfirmEmail(mailsetting, item.accountID);
            await _baseRepositoryAddress.CreateAsync(address);
            await SenderEmail(mailsetting, address);
            return new Respon_AddressReceive
            {
                addressID = address.ID,
                address = address.Address,
                phone = address.Phone,
                fullName = address.Full_Name,
                describe = address.Describe,
                email = address.Email
            };
        }


        public async Task<bool> Delete(long ID)
        {
            try
            {
                var entity = await _baseRepositoryAddress.GetAsync(record => record.ID == ID);
                entity.Deleted = true;
                await _baseRepositoryAddress.UpdateAsync(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Respon_AddressReceive> Update(long ID, Request_AddressReceive item)
        {
            var Entity = await _baseRepositoryAddress.GetAsync(record => record.ID == ID);
            Entity.Address = item.address;
            Entity.Phone = item.phone;
            Entity.Full_Name = item.fullName;
            Entity.Describe = item.describe;
            Entity.Email = item.email;
            await _baseRepositoryAddress.UpdateAsync(Entity);
            return new Respon_AddressReceive
            {
                addressID = Entity.ID,
                address = Entity.Address,
                phone = Entity.Phone,
                fullName = Entity.Full_Name,
                describe = Entity.Describe,
                email = Entity.Email
            };
        }

        public PageResult<Respon_AddressReceive> GetAll(Pagination pagination, string KeyWord)
        {
            return GetAll(null, pagination, KeyWord);
        }

        public PageResult<Respon_AddressReceive> GetAll(long? AccountID, Pagination pagination, string KeyWord)
        {

            var query = _baseRepositoryAddress.GetQueryable();
            if (AccountID.HasValue)
            {
                query = query.Where(record => record.AccountID == AccountID.Value);
            }
            if (KeyWord != null)
            {
                query = query.Where(record => record.Full_Name.ToLower().Contains(KeyWord.ToLower())
                                    || record.Address.ToLower().Contains(KeyWord.ToLower())
                                    || record.Email.ToLower().Contains(KeyWord.ToLower()));
            }
            var Data = query.Select(record => new Respon_AddressReceive
            {
                addressID = record.ID,
                address = record.Address,
                phone = record.Phone,
                fullName = record.Full_Name,
                describe = record.Describe,
                email = record.Email
            });
            pagination.TotalCount = Data.Count();
            var result = PageResult<Respon_AddressReceive>.ToPageResult(pagination, Data);
            return new PageResult<Respon_AddressReceive>(pagination, result);
        }

        public async Task<Respon_AddressReceive> GetByID(long AddressID)
        {
            var Data = await _baseRepositoryAddress.GetByIDAsync(AddressID);
            return new Respon_AddressReceive
            {
                addressID = Data.ID,
                address = Data.Address,
                phone = Data.Phone,
                fullName = Data.Full_Name,
                describe = Data.Describe,
                email = Data.Email
            };
        }
        public string Code(string code)
        {
            if (code.Length == 6)
            {
                return code;
            }
            else
            {
                string no = "";
                for (int i = 0; i < 6 - code.Length; i++)
                {
                    no += "0";
                }
                return no + code;
            }
        }

        public async Task SenderEmail(MailSetting mailSetting, Address_Receive address_Receive)
        {
            var confirm = await _baseRepositoryConfirm.GetAsync(record => record.Address_Receive.ID == address_Receive.ID && record.IsConfirmed == false);

            await _emailSender.SendEmailAsync(address_Receive.Email, mailSetting.TieuDe + "(" + mailSetting.Title + ")", string.Format(mailSetting.NoiDung, Code(confirm.CodeiVerification) + string.Format(mailSetting.Description, Code(confirm.CodeiVerification))));
        }
    }
}
