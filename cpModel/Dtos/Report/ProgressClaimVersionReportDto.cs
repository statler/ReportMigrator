using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class ProgressClaimVersionReportDto : ProgressClaimVersionDto
    {
        public bool useCert { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public List<ProgressClaimDetailReportDto> lstProgressClaimDetailsFlattened { get; set; }

        public decimal AmountPayableThisClaimEff => AmountThisClaimEff - (Retention ?? 0) - (Security ?? 0);

        public decimal AmountOwingClaimed => ClaimToDate - (Retention ?? 0) - (Security ?? 0) - PaidToDateValue;
        public decimal AmountOwingCertified => CertifiedValue - (Retention ?? 0) - (Security ?? 0) - PaidToDateValue;

        public decimal TotalClaimedEff => useCert ? CertifiedValue : ClaimToDate;
        public decimal AmountThisClaimEff => TotalClaimedEff - PreviousCertifiedValue;
        public decimal AmountOwingEff => useCert ? AmountOwingCertified : AmountOwingClaimed;
        public decimal GSTRate { get; set; }
    }
}
