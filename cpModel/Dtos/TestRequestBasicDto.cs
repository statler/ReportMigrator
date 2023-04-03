using cpModel.Enums;
using System;

namespace cpModel.Dtos
{
    public class TestRequestBasicDto
    {
        public int TestRequestId { get; set; }
        public int? TestRequestNo { get; set; }
        public DateTime? DateRequest { get; set; }
        public DateTime? DateRequired { get; set; }
        public string Description { get; set; }
        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public string RequestedByName { get; set; }
        public string RequestToName { get; set; }
        public int? TestResultStatus { get; set; }

        public TestRequestResultStatusEnum? TestResultStatus_enum { get => (TestRequestResultStatusEnum?)TestResultStatus; set => TestResultStatus = (int?)value; }
    }
}
