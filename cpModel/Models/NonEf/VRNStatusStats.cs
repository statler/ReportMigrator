using System.ComponentModel;

namespace cpModel.Models.NonEf
{
    public enum VRNStatusStats
    {
        [Description("Open")]
        Open = 1,
        [Description("Notified")]
        Notified = 2,
        [Description("Approved")]
        Approved = 3
    }
}
