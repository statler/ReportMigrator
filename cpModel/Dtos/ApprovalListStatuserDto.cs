using System;

namespace cpModel.Dtos
{
    public class ApprovalListStatuserDto
    {
        public int ApprovalId { get; set; }
        public string StatusLastStep { get; set; }
        public DateTime? DateLastStep { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool? IsLatestStepAlert { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsApprovedToProceed { get; set; }
        public string LastActionByName { get; set; }
        public string LastActionComment { get; set; }
        public string Status { get; set; }
        public DateTime? DateLastStatus { get; set; }
    }

}
// </auto-generated>
