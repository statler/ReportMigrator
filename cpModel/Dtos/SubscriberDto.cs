using System;
using System.Collections.Generic;
using System.Text;
using cpModel.Models;

namespace cpModel.Dtos
{
    public partial class SubscriptionDto
    {
        public int SubscriberId { get; set; }
        public string SubscriberName { get; set; }
        public string Email { get; set; }
        public string ContactPhone { get; set; }
        public string ContactName { get; set; }
        public DateTime? DateRegistered { get; set; }
        public DateTime? DateLastSubscription { get; set; }
        public DateTime? DateExpire { get; set; }
        public bool? IsActive { get; set; }
        public string UserPackType { get; set; }
        public string RenewalType { get; set; }
        public string PaymentType { get; set; }
        public string Notes { get; set; }
        public int UserCount { get; set; }
        public int AssocCount { get; set; }
    }
}
