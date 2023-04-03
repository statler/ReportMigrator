using System;

namespace cpModel.Dtos.Report
{
    public class LotSummaryReportDto
    {
        public string LotNumber { get; set; }
        public string Description { get; set; }
        public DateTime? DateConf { get; set; }
        public DateTime? DateGuar { get; set; }
        public DateTime? DateOpen { get; set; }
        public DateTime? DateRejected { get; set; }

        public DateTime? DateWorkSt { get; set; }
        public DateTime? DateWorkEnd { get; set; }

        public int NCRClosedCount { get; set; }
        public int NCRAppCount { get; set; }
        public int NCRUnAppCount { get; set; }
        public int ATPInspCount { get; set; }
        public int ATPInspUnAppCount { get; set; }
        public int QtyCount { get; set; }
        public int ZeroQtyCount { get; set; }
        public int TRCount { get; set; }
        public int TRIncompleteCount { get; set; }

        public string Status
        {
            get
            {
                if (DateRejected != null) return Models.Lot.RejectedString;
                if ((DateConf != null) && (DateConf != DateTime.MinValue)) return "Conformed";
                else if ((DateGuar != null) && (DateGuar != DateTime.MinValue)) return "Guaranteed";
                else return "Open";
            }
        }
    }
}
