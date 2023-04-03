

using System;

namespace cpModel.Dtos.Report
{
    public partial class NcrDateReportDto
    {
        public int NcrId { get; set; }
        public int? NcrNo { get; set; }
        public DateTime? DateRaised { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? CloseOutDate { get; set; }
    }

}
