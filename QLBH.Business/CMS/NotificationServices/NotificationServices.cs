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

        public async Task<DataResponse_Notification> Create(DataRequest_Notification data)
        {
            var Entity = new Notification
            {
                Notification_Title = data.Notification_Title,
                Notification_Description = data.Notification_Description,
                watched_at = false,
                AccountID = data.AccountID,
            };
            await _notificationRepository.CreateAsync(Entity);
            return new DataResponse_Notification
            {
                NotificationId = Entity.ID,
                Notification_Title = Entity.Notification_Title,
                Notification_Description = Entity.Notification_Description,
                watched_at = Entity.watched_at,
                AccountID = Entity.AccountID,
            };
        }

        public async Task<bool> Delete(long ID)
        {
            return await _notificationRepository.DeleteAsync(ID);
        }

        public async Task<IEnumerable<DataResponse_Notification>> GetAll()
        {
            var Data = await _notificationRepository.GetAllAsync();
            return Data.Select(item => new DataResponse_Notification
            {
                Notification_Title = item.Notification_Title,
                Notification_Description = item.Notification_Description,
                watched_at = item.watched_at,
                AccountID = item.AccountID,
            });
        }

        public async Task<IEnumerable<DataResponse_Notification>> GetByAccount(long AccountID)
        {
            var Data = await _notificationRepository.GetAllAsync(record => record.AccountID == AccountID);
            return Data.Select(item => new DataResponse_Notification
            {
                Notification_Title = item.Notification_Title,
                Notification_Description = item.Notification_Description,
                watched_at = item.watched_at,
                AccountID = item.AccountID,
            });
        }

        public async Task<DataResponse_Notification> Update(long ID, DataRequest_Notification data)
        {
            await Delete(ID);
            return await Create(data);
        }

        public async Task<DataResponse_Notification> Watched(long id)
        {
            var Data = await _notificationRepository.GetByIDAsync(id);
            Data.watched_at = true;
            await _notificationRepository.UpdateAsync(Data);
            return new DataResponse_Notification
            {
                Notification_Title = Data.Notification_Title,
                Notification_Description = Data.Notification_Description,
                watched_at = Data.watched_at,
                AccountID = Data.AccountID,
            };
        }
    }
}
