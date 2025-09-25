using ModernSchoolManagement.Dam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public interface INotificationModel
    {
        Task<IEnumerable<NotificationModel>> GetAllNotificationDetails();

        Task<NotificationModel> GetNotificationDetail(long Id);
        Task<NotificationModel> AddNotification(NotificationModel NotificationModel);
        Task<NotificationModel> UpdateNotification(NotificationModel NotificationModel);
        Task<NotificationModel> DeleteNotification(long Id);
    }
}
