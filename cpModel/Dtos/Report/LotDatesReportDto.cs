using cpModel.Interfaces;
using System;

namespace cpModel.Dtos.Report
{
    public class LotDatesReportDto: ILotDates
    {
        public string LotNumber { get; set; }
        public string Description { get; set; }
        public DateTime? DateConf { get; set; }
        public DateTime? DateGuar { get; set; }
        public DateTime? DateOpen { get; set; }
        public DateTime? DateRejected { get; set; }
        public DateTime? DateWorkSt { get; set; }
    }
}
