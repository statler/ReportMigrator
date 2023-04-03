using System;

namespace cpModel.Dtos
{
    public partial class ProgressClaimVersionDto
    //:ProgressClaimVersion
    {
        public int ProgressClaimVersionId { get; set; }
        public int? ProjectId { get; set; }
        public int? ReportPeriodId { get; set; }
        public DateTime? CutoffDate { get; set; }
        public int? VersionIx { get; set; }
        public bool? IsActive { get; set; }
        public string VersionDescription { get; set; }
        public bool? InclOpen { get; set; }
        public bool? InclGuar { get; set; }
        public bool? InclConf { get; set; }
        public int? PreviousReportPeriodId { get; set; }
        public decimal? PaidThisClaim { get; set; }
        public decimal? Retention { get; set; }
        public decimal? Security { get; set; }
        public bool? InclFloating { get; set; }
        public bool? InclNotAgreed { get; set; }
        public DateTime? ApprovedCompletionDate { get; set; }
        public DateTime? ForecastCompletionDate { get; set; }

        //Current Claim Summaries (calculated in controllers)
        public int? PreviousClaimVersionId { get; set; }
        public decimal ClaimToDate { get; set; }
        public decimal OverUnder { get; set; }
        public decimal CertifiedValue { get; set; }
        public decimal EarnedRevenue => ClaimToDate - OverUnder;
        public decimal ThisClaimDiff => ClaimToDate - PreviousClaimValue;
        public decimal ThisClaimVsPrevCert => ClaimToDate - PreviousCertifiedValue;
        public decimal ThisClaimCertVsPrevCert => CertifiedValue - PreviousCertifiedValue;
        public decimal PaidToDateValue { get; set; }
        public decimal AtCompletion { get; set; }
        public decimal ToComplete => CertifiedValue > 0 ? AtCompletion - CertifiedValue : AtCompletion - ClaimToDate;
        public decimal BudgetClaimed { get; set; }
        public decimal OverUnderBudget { get; set; }
        public decimal EarnedBudget => BudgetClaimed - OverUnderBudget;
        public decimal BudgetToComplete => BudgetAtCompletion - EarnedBudget;
        public decimal BudgetAtCompletion { get; set; }

        //Previous Claim Summaries (calculated in controllers)
        public decimal PreviousCertifiedValue { get; set; }
        public decimal PreviousClaimValue { get; set; }
        public decimal PreviousClaimBudget { get; set; }
        public decimal PreviousAtCompletion { get; set; }

        public string VersionDescriptionInclDate => $"{CutoffDate?.Date:d}: {VersionDescription}";





    }
}
