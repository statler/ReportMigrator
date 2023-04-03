using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class NotificationEditDto: NotificationDto
    {
        public NotificationToDto[] NotificationTos;
        public NotificationItemDto[] NotificationItems;
    }
}
