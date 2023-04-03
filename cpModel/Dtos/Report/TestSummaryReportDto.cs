namespace cpModel.Dtos.Report
{
    public struct TestSummaryReportDto
    {
        public int TestReqNo { get; set; }
        public int LotId { get; set; }
        public int? TestMethodId { get; set; }
        public string TestMethodName { get; set; }
        public string TestMethodDescription { get; set; }
        public string ScheduleName { get; set; }
        public string ScheduleDescription { get; set; }
        public int NoOfTests { get; set; }
        public bool AllCompleted { get; set; }
        public override string ToString() => $"{NoOfTests}x: {TestMethodName}";
        public string TestMethodNumDesc => $"{TestMethodName}: {TestMethodDescription}";
        public string ScheduleNameDesc
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ScheduleName)) return $"{ScheduleDescription}";
                else if (string.IsNullOrWhiteSpace(ScheduleDescription)) return $"{ScheduleName}";
                return $"{ScheduleName}: {ScheduleDescription}";
            }
        }
        public string ComplianceReq { get; set; }
    }
}
