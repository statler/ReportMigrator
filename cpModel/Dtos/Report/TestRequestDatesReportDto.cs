

using System;

namespace cpModel.Dtos.Report
{
    public partial class TestRequestDatesReportDto
    {
        public int TestRequestId { get; set; }
        public int? TestRequestNo { get; set; }
        public DateTime? DateRequest { get; set; }
        public DateTime? DateRequired { get; set; }
        public DateTime? DateTestCompleted { get; set; }
    }

}
