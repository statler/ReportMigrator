using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class NotificationItemDto : NotificationItemListDto
    {
        public string RequestComment { get; set; }
        public string Note { get; set; }

        public int? OptimisticLockField { get; set; }


    }
}
