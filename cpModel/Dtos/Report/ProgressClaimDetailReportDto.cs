
using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public partial class ProgressClaimDetailReportDto : ProgressClaimDetailDto
    {
        public List<ProgressClaimSnapshotReportDto> LstSnapshotItems { get; set; } = new List<ProgressClaimSnapshotReportDto>();

        public int Level { get; set; }
        public string SchedNumDescEff
        {
            get
            {
                if (IsSummaryLine) 
                    return $"Total: {SchedNumDesc}";
                else return $"{SchedNumDesc}";
            }
        }
        public bool IsHeading { get => QtyScheduled == null && SellRate == null; }
        public bool IsSummaryLine { get; set; } = false;

        public bool useCert { get; set; } = false;

        public string SchedNumDesc => string.IsNullOrWhiteSpace(ScheduleNumber) ? Description : $"{ScheduleNumber}: {Description}";


        public decimal? TotalClaimed => IsHeading ? (decimal?)null :
            Math.Round((SellRate ?? 0) * (QtyClaimed ?? 0), 2, MidpointRounding.AwayFromZero);
        public decimal? TotalCertified => IsHeading ? (decimal?)null :
            Math.Round((SellRateCert ?? 0) * (QtyCertified ?? 0), 2, MidpointRounding.AwayFromZero);
        public decimal? TotalPrevCertified => IsHeading ? (decimal?)null :
            Math.Round((SellRatePrev ?? 0) * (QtyPreviousCertified ?? 0), 2, MidpointRounding.AwayFromZero);
        public decimal? TotalScheduled => IsHeading ? (decimal?)null :
            Math.Round((SellRate ?? 0) * (QtyScheduled ?? 0), 2, MidpointRounding.AwayFromZero);


        public decimal? TotalScheduleEff
        {
            get
            {
                if (IsSummaryLine) return ChildTotalSchedSell;
                else return TotalScheduled;
            }
        }
        public decimal? QtyToDateEff => useCert ? QtyCertified : QtyClaimed;

        public decimal? SellRateEff => useCert ? SellRateCert : SellRate;

        public decimal? TotalToDateEff
        {
            get
            {
                if (IsSummaryLine) return useCert ? ChildTotalCertSell : ChildTotalClaimSell;
                else return useCert ? TotalCertified : TotalClaimed;
            }
        }

        public decimal? QtyPreviousCertifiedEff => IsHeading || IsSummaryLine ? (decimal?)null : (QtyPreviousCertified ?? 0);

        public decimal? TotalPrevCertEff => IsSummaryLine ? ChildTotalPrevCertSell : TotalPrevCertified;

        public decimal QtyThisClaimEff => (QtyToDateEff ?? 0) - (QtyPreviousCertified ?? 0);

        public decimal SellThisClaimEff => QtyThisClaimEff == 0 ? 0 : TotalThisClaimEff / QtyThisClaimEff;

        public decimal TotalThisClaimEff => (TotalToDateEff ?? 0) - (TotalPrevCertEff ?? 0);
        public decimal? QtyAtCompletionEff => IsHeading || IsSummaryLine ? (decimal?)null : (QtyAtCompl ?? 0);
        public decimal? TotalAtCompletionEff => IsSummaryLine ? ChildTotalAtCompSell : TotalPrevCertified;
        public decimal? QtyToCompleteEff => IsHeading || IsSummaryLine ? (decimal?)null : (QtyAtCompletionEff ?? 0) - (QtyToDateEff ?? 0);
        public decimal? TotalToCompleteEff => TotalAtCompletionEff - TotalToDateEff;
    }
}
