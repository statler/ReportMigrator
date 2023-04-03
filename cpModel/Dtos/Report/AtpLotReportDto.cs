using System;

namespace cpModel.Dtos.Report
{
    public partial class AtpLotReportDto
    {
        public int? AtpId { get; set; }
        public int? AtpNo { get; set; }
        public string AtpDescription { get; set; }
        public DateTime? ATPDate { get; set; }
        public int? LotId { get; set; }
        public string ItemInspect { get; set; }
        public DateTime? DateInspect { get; set; }
        public DateTime? TimeInspect { get; set; }
        public DateTime? DateApproved { get; set; }
        public int? ApprovedById { get; set; }
        public string ApprovedByName { get; set; }
        public string ApprovalComments { get; set; }
        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public string LotNumDescription => $"{LotNumber}: {LotDescription}";

        public string TimeAsString => TimeInspect.HasValue ? TimeInspect.Value.ToString("t") : "";

        public string FullDescription => $"{LotNumber}: {ItemInspect}";
    }

}
