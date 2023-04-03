using System;
using System.Collections.Generic;
using System.Text;
using cpModel.Models;

namespace cpModel.Dtos
{
    public partial class SubscriberControlDto
    {
        public int SystemSubscriberControlId { get; set; }
        public int? SubscriberId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
