using QLBH.Models.Entities;
using QLBH.Models;
using QLBH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public class NotificationServices : INotificationServices
    {
        private readonly IBaseRepository<Notification> _notificationRepository;

        public NotificationServices(IBaseRepository<Notification> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task Create(DataRequest_Notification data)
        {
            var Entity = new Notification
            {
                Notification_Title = data.notificationTitle,
                Notification_Description = data.notificationDescription,
                watched_at = false,
                AccountID = data.accountID,
            };
            await _notificationRepository.CreateAsync(Entity);
        }

        public async Task Delete(long ID)
        {
            await _notificationRepository.DeleteAsync(ID);
        }

        public IEnumerable<DataResponse_Notification> GetAll()
        {
            return GetAll(0);
        }

        public IEnumerable<DataResponse_Notification> GetAll(long accountID)
        {

            var query = _notificationRepository.GetQueryable();
            if (accountID > 0)
            {
                query = query.Where(record => record.AccountID == accountID);
            }
            return query.Select(item => new DataResponse_Notification
            {
                notificationTitle = item.Notification_Title,
                notificationDescription = item.Notification_Description,
                watched_at = item.watched_at,
                accountID = item.AccountID,
            });
        }

        public async Task Update(long ID, DataRequest_Notification data)
        {
            await Delete(ID);
        }

        public async Task<DataResponse_Notification> Watched(long id)
        {
            var Data = await _notificationRepository.GetByIDAsync(id);
            Data.watched_at = true;
            await _notificationRepository.UpdateAsync(Data);
            return new DataResponse_Notification
            {
                notificationTitle = Data.Notification_Title,
                notificationDescription = Data.Notification_Description,
                watched_at = Data.watched_at,
                accountID = Data.AccountID,
            };
        }
    }
}
