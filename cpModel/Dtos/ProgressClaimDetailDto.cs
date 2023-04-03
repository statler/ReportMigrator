namespace cpModel.Dtos
{
    public partial class ProgressClaimDetailDto
    {
        public int ProgressClaimDetailId { get; set; }
        public int? ProgressClaimVersionId { get; set; }
        public int? ReportPeriodId { get; set; }
        public int? ScheduleId { get; set; }
        public decimal? QtyPreviousCertified { get; set; }
        public decimal? DjcRatePrev { get; set; }
        public decimal? SellRatePrev { get; set; }
        public decimal? QtyCertified { get; set; }
        public decimal? SellRateCert { get; set; }
        public decimal? QtyOverUnder { get; set; }
        public decimal? QtyClaimed { get; set; }
        public decimal? DjcRate { get; set; }
        public decimal? SellRate { get; set; }
        public decimal? QtyAtCompl { get; set; }
        public decimal? DjcRateAtComp { get; set; }
        public decimal? SellRateAtComp { get; set; }
        public decimal? RiskOpp { get; set; }
        public bool? IsOverhead { get; set; }
        public bool? IsVariableRate { get; set; }
        public decimal? OrderId { get; set; }
        public int? ParentId { get; set; }
        public string ScheduleNumber { get; set; }
        public string Description { get; set; }
        public decimal? QtyScheduled { get; set; }
        public string Unit { get; set; }
        public bool? IsTotalled { get; set; }
        public string Notes { get; set; }
        public bool? IsVrn { get; set; }



        public decimal? LotQty { get; set; }
        public decimal? EffLotQty { get; set; }
        public decimal? EffIncLotQty { get; set; }
        public int ChildCountTopLevel { get; set; } = 0;
        public int ChildCount { get; set; } = 0;

        public decimal ChildTotalClaimDjc { get; set; } = 0;
        public decimal ChildTotalClaimSell { get; set; } = 0;
        public decimal ChildTotalCertDjc { get; set; } = 0;
        public decimal ChildTotalCertSell { get; set; } = 0;
        public decimal ChildTotalAtCompDjc { get; set; } = 0;
        public decimal ChildTotalAtCompSell { get; set; } = 0;
        public decimal ChildTotalSchedDjc { get; set; } = 0;
        public decimal ChildTotalSchedSell { get; set; } = 0;
        public decimal ChildTotalPrevDjc { get; set; } = 0;
        public decimal ChildTotalPrevCertSell { get; set; } = 0;

        public decimal? DjcTotal { get; set; }
        public decimal? SellTotal { get; set; }


    }
}
