using System;
using System.Linq;

namespace cpModel.Enums
{
    public enum ProgressClaimStatusEnum
    {
        Open = 1,
        Guaranteed,
        Conformed,
        Previously_Guaranteed,
        Previously_Conformed,
        Floating,
        Previously_Floating
    }
}
