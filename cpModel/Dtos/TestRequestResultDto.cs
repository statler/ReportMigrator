using System;

namespace cpModel.Dtos
{
    public class TestRequestResultDto : TestResultDto
    {
        public int TestRequestTestId { get; set; }
        public int TestRequestNo { get; set; }
        public string LotNumber { get; set; }
        public string SampleNo { get; set; }
        public DateTime? DateSampled { get; set; }
        public int? TestMethodId { get; set; }

    }
}
