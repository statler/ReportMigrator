using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class ProjectUserDto
    {
        public int ProjectUserId { get; set; }
        public int? ProjectId { get; set; }
        public int? UserId { get; set; }
        public int? OptimisticLockField { get; set; }
        public UserBasicDto User { get; set; }
    }
}
