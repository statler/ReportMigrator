using cpModel.Enums;
using System;

namespace cpModel.Dtos
{
    public partial class ProgressClaimVersion_add
    {
        public int? ReportPeriodId { get; set; }
        public DateTime? CutoffDate { get; set; }
        public bool? IsActive { get; set; }
        public string VersionDescription { get; set; }
        public int? PreviousReportPeriodId { get; set; }
        public decimal? Security { get; set; }
        public bool LimitQtyToCutoffDate { get; set; }
        public ClaimQtyCalcEnum ClaimQtyCalc { get; set; }
        public bool UseLotQty { get; set; }
        public bool? InclOpen { get; set; }
        public bool? InclGuar { get; set; }
        public bool? InclConf { get; set; }
        public bool? InclFloating { get; set; }
        public bool? InclNotAgreed { get; set; }
        public decimal? PaidThisClaim { get; set; }
        public decimal? Retention { get; set; }
        public bool LockOtherClaims { get; set; } = true;
    }
}
