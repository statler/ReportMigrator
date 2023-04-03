using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class NotificationItemListDto
    {
        public int NotificationItemId { get; set; }
        public int? NotificationId { get; set; }
        public int? ItemId { get; set; }
        public string ItemReference { get; set; }
        public DateTime? ActionDate { get; set; }
        public int? ActionById { get; set; }
        public bool? IsSoftDeleted { get; set; }



    }
}
