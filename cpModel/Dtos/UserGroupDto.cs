using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class UserGroupDto
    {
        public int UserGroupId { get; set; }
        public int? GroupId { get; set; }
        public int? UserId { get; set; }
        public string GroupName { get; set; }
        public string UserFullName { get; set; }
    }
}
