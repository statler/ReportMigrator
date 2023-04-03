using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class NotificationListDto
    {
        public int NotificationId { get; set; }
        public int? NotificationNo { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? NoticeDate { get; set; }
        public int? NoticeById { get; set; }
        public int? RegisterId { get; set; }
        public string SubjectText { get; set; }
        public DateTime? ActionDate { get; set; }
        public int? ActionById { get; set; }
        public DateTime? DateRequiredBy { get; set; }
        public bool? IsSoftDeleted { get; set; }

        public int? NotificationTypeId { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime? DateDismissed { get; set; }
        public DateTime? PublishDate { get; set; }

        public int ItemCount { get; set; }
        public int ItemCount_Actioned { get; set; }


        public string NoticeByName { get; set; }

        public NotificationTypeEnum? NotificationType => NotificationTypeId == null ? null : (NotificationTypeEnum?)NotificationTypeId;

        public bool IsDismissed => DateDismissed != null;
        public bool IsPublished => PublishDate != null;
        public bool IsRead => DateRead != null;

        public NotificationStatusEnum Status
        {
            get
            {
                if (ActionDate != null) return NotificationStatusEnum.Actioned;
                else
                {
                    if (NotificationType == null) return NotificationStatusEnum.Not_Actioned;
                    else if (NotificationType == NotificationTypeEnum.Information) return NotificationStatusEnum.Information;
                    else return NotificationStatusEnum.Action_Required;
                }
            }
        }

        public string StatusString => Status.ToString().Replace("_", " ");
    }
}
