using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Models
{
    public class NotificationModel
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string NotificationType { get; set; }
        public string Message { get; set; }
        public int Object_Id { get; set; }
        public int ActivityTypeId { get; set; }
        public bool Is_read { get; set; }
        public DateTime Notifytime { get; set; }

    }
}
