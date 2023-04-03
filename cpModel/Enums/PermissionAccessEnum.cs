using System;
using System.Linq;

namespace cpModel.Enums
{
    public enum PermissionAccessEnum
    {
        View = 1,
        Add = 2,
        Edit = 3,
        Admin_Delete = 4,
        Absolute = 10, 
        View_Limited = 101
    }
}
