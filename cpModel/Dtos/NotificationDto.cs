using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class NotificationDto: NotificationListDto
    {
        public string ContentHtml { get; set; }
        public string ActionComment { get; set; }
        public int? OptimisticLockField { get; set; }

        public string ApprovalStatus
        {
            get
            {
                string s = "Not statused";
                if (ActionDate != null) s = $"Actioned: {ActionDate:d}";
                else
                {
                    s = $"In progress: {ItemCount_Actioned}/{ItemCount} complete";
                }
                return s;
            }
        }
    }
}
