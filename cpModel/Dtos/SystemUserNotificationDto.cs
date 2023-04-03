using cpModel.Enums;
using cpShared.Extensions;
using System;

namespace cpModel.Dtos
{
    public class SystemUserNotificationDto : SystemUserControlDto
    {
        public int? NotificationTypeId { get => Value.ParseInt(); set => Value = value.ToString(); }
        public int EffNotificationTypeId => NotificationTypeId ?? (int)UserNotificationTypeEnum.Project_Setting;
        public UserNotificationTypeEnum EffNotificationType { get => (UserNotificationTypeEnum)EffNotificationTypeId; set => NotificationTypeId = (int)value; }
        public SystemUserNotificationDto(int userId, string userFullName, int notificationTypeId)
        {
            UserId = userId;
            FullName = userFullName;
            NotificationTypeId = notificationTypeId;
        }

        public SystemUserNotificationDto()
        {
        }
    }
}
