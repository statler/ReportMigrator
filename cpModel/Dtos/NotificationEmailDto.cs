using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class NotificationEmailDto
    {
        public int NotificationEmailId { get; set; }
        public int? NotificationId { get; set; }
        public int? EmailLogId { get; set; }
        public int? EmailLogNo { get; set; }
        public DateTime? EmailDate { get; set; }

        public int? NotificationNo { get; set; }
        public DateTime NoticeDate { get; set; }
        public string EmailDescription => $"{EmailLogNo}: ({EmailDate:d})";
    }
}
