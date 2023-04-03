using System.ComponentModel;

namespace cpModel.Models.NonEf
{

    public enum LotStatus
    {
        [Description("Open")]
        Open = 1,
        [Description("Guaranteed")]
        Guaranteed = 2,
        [Description("Conformed")]
        Conformed = 3,
        [Description("Rejected")]
        Rejected = 4,
        [Description("PreOpen")]
        PreOpen = 5,
    }

}