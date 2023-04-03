namespace cpModel.Dtos
{
    public partial class UserRolePermsDto
    {
        public int UserRoleId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public int? ProjectId { get; set; }

        public string RoleName { get; set; }
        public string FullName { get; set; }
    }
}
