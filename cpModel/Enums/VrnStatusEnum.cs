using System;
using System.Linq;

namespace cpModel.Enums
{
    public enum VrnStatusEnum
    {
        Identified = 1,
        Notified = 2,
        Submitted = 3,
        Conditionally_Approved = 4,
        Approved_In_Principle = 5,
        Approved = 6,
        Rejected = 7,
        Resubmit = 8,
        Abandoned = 9,
        Other = 10
    }
}
