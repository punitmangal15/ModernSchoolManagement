using Dapper;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;
using System.Data;
namespace ModernSchoolManagement.Dam.Services
{
    public class NotificationService : INotificationModel
    {
        private readonly IDynamicRepository dynamicRepository;

        public NotificationService(IDynamicRepository dynamicRepository)
        {
            this.dynamicRepository = dynamicRepository;
        }

        public async Task<IEnumerable<NotificationModel>> GetAllNotificationDetails()
        {
            string sp = "dbo.sp_GetAllNotification";
            try
            {
                return await dynamicRepository.GetAll<NotificationModel>(sp, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch notification details.", ex);
            }
        }

        public async Task<NotificationModel> GetNotificationDetail(long Id)
        {
            string sp = "dbo.sp_GetNotificationDetail";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@NotificationId", Id);
            try
            {
                return await dynamicRepository.Get<NotificationModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch notification detail.", ex);
            }

        }

        public async Task<NotificationModel> AddNotification(NotificationModel NotificationModel)
        {
            string sp = "dbo.sp_AddNotification";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", NotificationModel.UserId);
            dynamicParameters.Add("@NotificationType", NotificationModel.NotificationType);
            dynamicParameters.Add("@Message", NotificationModel.Message);
            dynamicParameters.Add("@Object_Id", NotificationModel.Object_Id);
            dynamicParameters.Add("@ActivityTypeId", NotificationModel.ActivityTypeId);
            dynamicParameters.Add("@Is_read", NotificationModel.Is_read);
            dynamicParameters.Add("@Notifytime", NotificationModel.Notifytime);
            try
            {
                return dynamicRepository.Add<NotificationModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add notification.", ex);
            }
        }
        public async Task<NotificationModel> UpdateNotification(NotificationModel NotificationModel)
        {
            string sp = "dbo.sp_UpdateNotification";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@NotificationId", NotificationModel.NotificationId);
            dynamicParameters.Add("@UserId", NotificationModel.UserId);
            dynamicParameters.Add("@NotificationType", NotificationModel.NotificationType);
            dynamicParameters.Add("@Message", NotificationModel.Message);
            dynamicParameters.Add("@Object_Id", NotificationModel.Object_Id);
            dynamicParameters.Add("@ActivityTypeId", NotificationModel.ActivityTypeId);
            dynamicParameters.Add("@Is_read", NotificationModel.Is_read);
            dynamicParameters.Add("@Notifytime", NotificationModel.Notifytime);
            try
            {
                return dynamicRepository.Update<NotificationModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update notification.", ex);
            }
        }
        public async Task<NotificationModel> DeleteNotification(long Id)
        {
            string sp = "dbo.sp_DeleteNotification";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@NotificationId", Id);
            try
            {
                return dynamicRepository.Delete<NotificationModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete notification.", ex);
            }
        }

    }
}
