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
            return await _NotificationDetails.GetAllNotificationDetails();
            //return Ok(users);
        }

        [HttpGet(Name = "GetNotificationDetail")]
        [AllowAnonymous]
        public Task<NotificationModel> GetNotificationDetail(long Id)
        {
            return _NotificationDetails.GetNotificationDetail(Id);
            //return Ok(users);
        }

        [HttpPost(Name = "AddNotification")]
        [AllowAnonymous]
        public Task<NotificationModel> AddNotification(NotificationModel NotificationModel)
        {
            return _NotificationDetails.AddNotification(NotificationModel);
            //return Ok(users);
        }

        [HttpPost(Name = "UpdateNotification")]
        [AllowAnonymous]
        public Task<NotificationModel> UpdateNotification(NotificationModel NotificationModel)
        {
            return _NotificationDetails.UpdateNotification(NotificationModel);
            //return Ok(users);
        }

        [HttpPost(Name = "DeleteNotification")]
        [AllowAnonymous]
        public Task<NotificationModel> DeleteNotification(long Id)
        {
            return _NotificationDetails.DeleteNotification(Id);
            //return Ok(users);
        }
    }
}
