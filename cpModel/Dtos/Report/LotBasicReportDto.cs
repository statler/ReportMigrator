using System;

namespace cpModel.Dtos.Report
{
    public partial class LotBasicReportDto
    {
        public int LotId { get; set; }
        public string LotNumber { get; set; }
        public string Description { get; set; }
        public DateTime? DateOpen { get; set; }

        public decimal? RpValue { get; set; }

    }
}
