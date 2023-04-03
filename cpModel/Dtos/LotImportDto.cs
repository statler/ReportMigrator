using System;

namespace cpModel.Dtos
{
    public class LotImportDto
    {
        public string LotNumber { get; set; }
        public string AreaCodeName { get; set; }
        public string WorkTypeName { get; set; }
        public string ControlLineName { get; set; }
        public string Description { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime? DateConf { get; set; }
        public DateTime? DateGuar { get; set; }
        public DateTime? DateOpen { get; set; }
        public DateTime? DateWorkEnd { get; set; }
        public DateTime? DateWorkSt { get; set; }
        public decimal? PercentComplete { get; set; }
        public decimal? ChStart { get; set; }
        public decimal? StLeftOs { get; set; }
        public decimal? StRightOs { get; set; }
        public decimal? ChEnd { get; set; }
        public decimal? EndLeftOs { get; set; }
        public decimal? EndRightOs { get; set; }
        public string Rl1 { get; set; }
        public string Rl2 { get; set; }
        public decimal? NominalThickness { get; set; }
        public string Notes { get; set; }
        public DateTime? DateRejected { get; set; }
    }
}