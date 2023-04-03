using cpModel.Enums;

namespace cpModel.Dtos
{
    public partial class RoleDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int? SubscriberId { get; set; }
        public decimal? PoApprovalLimit { get; set; }
        public decimal? InvoiceApprovalLimit { get; set; }
        public SubscriptionRoleTypeEnum? SubscriptionRoleType { get; set; }
    }
}
