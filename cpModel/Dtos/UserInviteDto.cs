using System;

namespace cpModel.Dtos
{
    public partial class UserInviteDto
    {
        public int UserInviteId { get; set; }
        public int? ProjectId { get; set; }
        public string ProjectNumberAndName { get; set; }
        public int? RoleId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid? UniqueId { get; set; }
        public bool? IsAccepted { get; set; }
        public bool? IsSubscriptionAdmin { get; set; }

        public RoleDto Role { get; set; }
    }
}
