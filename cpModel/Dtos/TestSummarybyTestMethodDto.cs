using System;
using System.Collections.Generic;

namespace cpModel.Dtos
{

    public struct TestSummarybyTestMethodDto
    {
        public int TestReqId { get; set; }
        public int TestReqNo { get; set; }
        public DateTime? DateRequest { get; set; }
        public DateTime? DateRequired { get; set; }
        public string RequestByName { get; set; }
        public string RequestToName { get; set; }
        public int? TestResultStatus { get; set; }
        public string LotNumber { get; set; }
        public int? TestMethodId { get; set; }
        public string TestMethodName { get; set; }
        public string TestDescription { get; set; }
        public int NoOfTests { get; set; }
        //public int AverageTurnaround { get; set; }
        //public int AgreedTurnaround { get; set; }
        public DateTime? LatestUploadDate { get; set; }
        public int UploadCount { get; set; }
        public bool AllCompleted { get; set; }
        public List<int> TestIds { get; set; }
        public override string ToString() => $"{NoOfTests}x: {TestMethodName}";
    }
}
