using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace QLBH.Business
{
    public class MailSettingServices : IMailSettingServices
    {
        private readonly IBaseRepository<MailSetting> _MailSettingRepository;

        public MailSettingServices(IBaseRepository<MailSetting> mailSettingRepository)
        {
            _MailSettingRepository = mailSettingRepository;
        }

        public Task<DataResponse_MailSetting> Create(DataRequest_MailSetting data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DataResponse_MailSetting>> GetAllMail()
        {
            var Data = await _MailSettingRepository.GetAllAsync();
            return Data.Select(item => new DataResponse_MailSetting
            {
                Code = item.Code,
                TieuDe = item.TieuDe,
                NoiDung = item.NoiDung,
                Title = item.Title,
                Description = item.Description,
            });
        }

        public Task<DataResponse_MailSetting> Update(long ID, DataRequest_MailSetting data)
        {
            throw new NotImplementedException();
        }
    }
}
