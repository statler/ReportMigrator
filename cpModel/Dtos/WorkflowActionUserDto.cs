using System;

namespace cpModel.Dtos
{
    public partial class WorkflowActionUserDto
    {
        public int WorkflowActionUserId { get; set; }
        public int? WorkflowActionId { get; set; }
        public int? UserId { get; set; }
        public Guid? UserGuid { get; set; }

        //If this is in, then you need to modify the reverse map to ignore
        //public virtual UserDto User { get; set; }
    }

}

