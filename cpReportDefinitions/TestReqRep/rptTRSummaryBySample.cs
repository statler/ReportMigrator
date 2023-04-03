namespace cpReportDefinitions.TestReqRep
{
    public partial class rptTRSummaryBySample : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Test Req Summary (by sample)";

        public rptTRSummaryBySample()
        {
            InitializeComponent();
            ReportTitle = "Test Req Summary (by sample)";
        }

    }
}
