using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class LotItpLotQuantityReportDto
    {
        public int QuantityId { get; set; }
        public int? LotId { get; set; }
        public int? LotItpId { get; set; }
        public string ScheduleNo { get; set; }
        public string ScheduleDescription { get; set; }
        public decimal? PercComp { get; set; }
        public decimal? Qty { get; set; }
        public string Unit { get; set; }
    }
}
