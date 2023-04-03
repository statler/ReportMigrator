using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class NotificationToDto
    {
        public int NotificationToId { get; set; }
        public int? NotificationId { get; set; }
        public int? UserId { get; set; }
        public int? NotificationTypeId { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime? DateDismissed { get; set; }
        public int? PriorityId { get; set; }
    }
}
