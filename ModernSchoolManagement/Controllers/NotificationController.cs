using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernSchoolManagement.Authentication;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;

namespace ModernNotificationManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class NotificationController : Controller
    {

        private readonly IAuthentication _authentication;
        private readonly ILogger<NotificationController> _logger;
        private readonly INotificationModel _NotificationDetails;
        public NotificationController(IAuthentication authentication, ILogger<NotificationController> logger, INotificationModel NotificationModel)
        {
            _authentication = authentication;
            _logger = logger;
            _NotificationDetails = NotificationModel;

        }
        [HttpGet(Name = "GetAllNotificationDetails")]
        [AllowAnonymous]
        public async Task<IEnumerable<NotificationModel>> GetAllNotificationDetails()
        {
            _logger.LogInformation("Fetching all notification details.");
            try
            {
                var notifications = await _NotificationDetails.GetAllNotificationDetails();
                _logger.LogInformation("Fetched {Count} notifications.", notifications?.Count() ?? 0);
                return notifications;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all notification details.");
                throw;
            }
        }

        [HttpGet(Name = "GetNotificationDetail")]
        [AllowAnonymous]
        public async Task<NotificationModel> GetNotificationDetail(long Id)
        {
            _logger.LogInformation("Fetching notification detail for Id: {Id}", Id);
            try
            {
                var notification = await _NotificationDetails.GetNotificationDetail(Id);
                if (notification == null)
                {
                    _logger.LogWarning("Notification with Id: {Id} not found.", Id);
                }
                else
                {
                    _logger.LogInformation("Fetched notification detail for Id: {Id}", Id);
                }
                return notification;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching notification detail for Id: {Id}", Id);
                throw;
            }
        }

        [HttpPost(Name = "AddNotification")]
        [AllowAnonymous]
        public async Task<NotificationModel> AddNotification(NotificationModel NotificationModel)
        {
            _logger.LogInformation("Adding new notification for UserId: {UserId}, Type: {Type}", NotificationModel.UserId, NotificationModel.NotificationType);
            try
            {
                var result = await _NotificationDetails.AddNotification(NotificationModel);
                _logger.LogInformation("Added notification with Id: {Id}", result.NotificationId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding notification for UserId: {UserId}", NotificationModel.UserId);
                throw;
            }
        }

        [HttpPost(Name = "UpdateNotification")]
        [AllowAnonymous]
        public async Task<NotificationModel> UpdateNotification(NotificationModel NotificationModel)
        {
            _logger.LogInformation("Updating notification with Id: {Id}", NotificationModel.NotificationId);
            try
            {
                var result = await _NotificationDetails.UpdateNotification(NotificationModel);
                _logger.LogInformation("Updated notification with Id: {Id}", result.NotificationId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating notification with Id: {Id}", NotificationModel.NotificationId);
                throw;
            }
        }

        [HttpPost(Name = "DeleteNotification")]
        [AllowAnonymous]
        public async Task<NotificationModel> DeleteNotification(long Id)
        {
            _logger.LogInformation("Deleting notification with Id: {Id}", Id);
            try
            {
                var result = await _NotificationDetails.DeleteNotification(Id);
                _logger.LogInformation("Deleted notification with Id: {Id}", Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting notification with Id: {Id}", Id);
                throw;
            }
        }

    }
}
