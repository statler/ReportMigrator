using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public class RoleSummaryDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int? SubscriberId { get; set; }
        public int ViewLimitedPermissionCount { get; set; }
        public int ViewPermissionCount { get; set; }
        public int AddPermissionCount { get; set; }
        public int EditPermissionCount { get; set; }
        public int Admin_DeletePermissionCount { get; set; }
        public int AbsolutePermissionCount { get; set; }
    }
}
