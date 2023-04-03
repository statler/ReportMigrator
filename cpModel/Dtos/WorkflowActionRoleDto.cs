namespace cpModel.Dtos
{
    public partial class WorkflowActionRoleDto
    {
        public int WorkflowActionRoleId { get; set; }
        public int? WorkflowActionId { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }

        //If this is in, then you need to modify the reverse map to ignore
        //public virtual RoleDto Role { get; set; }
    }

}

