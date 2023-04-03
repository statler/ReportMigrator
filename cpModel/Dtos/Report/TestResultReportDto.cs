namespace cpModel.Dtos.Report
{
    public partial class TestResultReportDto
    {
        public int TestResultId { get; set; }
        public int TestReqId { get; set; }
        public int? TestId { get; set; }
        public int? TestResultFieldId { get; set; }
        public decimal? OrderId { get; set; }
        public string TestMethod { get; set; }
        public string TestMethodDescription { get; set; }
        public string ResultUnit { get; set; }
        public string SampleName { get; set; }
        public string Result { get; set; }
        public string ResultFieldName { get; set; }
        public double? ResultAsDouble => double.TryParse(Result, out double resultDec) ? resultDec : null as double?;

    }

}
