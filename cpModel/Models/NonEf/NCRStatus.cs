using System.ComponentModel;

namespace cpModel.Models.NonEf
{

    public enum NCRStatus
    {
        [Description("Open")]
        Open = 1,
        [Description("Approved")]
        Approved = 2,
        [Description("ClosedOut")]
        ClosedOut = 3,
    }
}
