using cpModel.Dtos;

namespace cpModel.Dtos
{
    public class UserRoleSubscriptionInfoDto
    {
        public int UserRoleId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public int? ProjectId { get; set; }

        public RoleSummaryDto Role { get; set; }

    }
}
