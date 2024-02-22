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

        public Task Create(DataRequest_MailSetting data)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataResponse_MailSetting> GetAllMail()
        {
            var Data = _MailSettingRepository.GetQueryable();
            return Data.Select(item => new DataResponse_MailSetting
            {
                code = item.Code,
                tieuDe = item.TieuDe,
                noiDung = item.NoiDung,
                title = item.Title,
                description = item.Description,
            });
        }

        public Task Update(long ID, DataRequest_MailSetting data)
        {
            throw new NotImplementedException();
        }
    }
}
