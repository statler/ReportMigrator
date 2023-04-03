
using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public partial class TestRequestTestReportDto
    {
        public int? LotId { get; set; }
        public string LotNumber { get; set; }
        public int TestRequestId { get; set; }
        public int TestRequestTestId { get; set; }
        public string SampleId { get; set; }
        public int? TestMethodId { get; set; }
        public int? TestRequestNo { get; set; }
        public string TestMethodNum { get; set; }
        public string TestMethodDesc { get; set; }
        public int? ScheduleId { get; set; }
        public string ScheduleNo { get; set; }
        public string ScheduleDescription { get; set; }
        public DateTime? DateSampled { get; set; }
        public DateTime? TrDateSampled { get; set; }
        public int? ControlLineId { get; set; }
        public decimal? Xref { get; set; }
        public decimal? Yref { get; set; }
        public decimal? Zref { get; set; }
        public bool? ManualOverride { get; set; }
        public string Notes { get; set; }
        public bool? TestComplete { get; set; }
        public string ComplianceReq { get; set; }
        public bool TestReqMarkedComplete { get; set; }

        public string TestMethodNumDesc => $"{TestMethodNum}: {TestMethodDesc}";

        public List<TestResultReportDto> Results { get; set; }

        public DateTime? TestDate
        {
            get
            {
                if (DateSampled != null) return (DateTime)DateSampled;
                else return TrDateSampled;
            }
        }

    }
}
