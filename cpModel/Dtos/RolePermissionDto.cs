using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public partial class RolePermissionDto
    {
        public int RolePermissionId { get; set; }
        public int? RoleId { get; set; }
        public int? PermissionId { get; set; }
        public bool? Allowed { get; set; }
        public int? RegisterKey { get; set; }
        public int? AccessKey { get; set; }

        public RoleDto Role { get; set; }
    }
}
