namespace cpModel.Dtos
{
    public partial class UserRoleDto
    {
        public int UserRoleId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public int? ProjectId { get; set; }
        public int? SubscriberId { get; set; }

        public RoleDto Role { get; set; }
        public ProjectExtDto Project { get; set; }
        public UserDto User { get; set; }
    }
}
