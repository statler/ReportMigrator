using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class TestRequestTestForSummaryDto
    {
        public int TestRequestTestId { get; set; }
        public string SampleId { get; set; }
        public int? TestMethodId { get; set; }
        public int? TestRequestId { get; set; }
        public int? ScheduleId { get; set; }
        public DateTime? DateSampled { get; set; }
        public int? ControlLineId { get; set; }
        public bool? TestComplete { get; set; }
    }

}
