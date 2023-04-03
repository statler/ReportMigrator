using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.TestReqRep
{
    public partial class rptTRSummaryByType : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Test Req Summary (by test type)";

        public rptTRSummaryByType()
        {
            InitializeComponent();
            ReportTitle = "Test Req Summary (by test type)";
        }

        private void lbIsComplete_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase report = (sender as XRLabel).Band.Report;
            var isAllCompleted = report.GetCurrentColumnValue("AllCompleted") as bool?;
            lbIsComplete.Text = (isAllCompleted ?? false) ? "*" : "-";
        }
    }
}
