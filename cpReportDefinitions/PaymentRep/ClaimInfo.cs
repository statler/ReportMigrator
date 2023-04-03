using System;

namespace cpReportDefinitions.PaymentRep
{
    public class ClaimInfo
    {
        public DateTime? SplitDate { get; set; } = DateTime.MinValue;
        public bool UseLongDescriptions { get; set; } = false;
        public bool UseCertQty { get; set; } = false;
        public ClaimInfo()
        {

        }
    }
}
