using cpModel.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class NotificationForTreeDto
    {
        public int? NotificationId { get; set; }

        [JsonIgnore]
        public ICollection<FsNotificationDto> FilestoreDocs { get; set; } = new List<FsNotificationDto>();
        [JsonIgnore]
        public ICollection<NotificationItemDto> ApprovalCcs { get; set; } = new List<NotificationItemDto>();
    }
}
