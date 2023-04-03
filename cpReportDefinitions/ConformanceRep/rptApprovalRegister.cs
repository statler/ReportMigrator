using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.ConformanceRep
{
    public partial class rptApprovalRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Approval Register";

        public rptApprovalRegister()
        {
            InitializeComponent();
            ReportTitle = "Approval Register";
            IsRegisterReport = true;
            xrREReqSub.BeforePrint += xrREReqText_BeforePrint;
        }


        private void xrREReqText_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            xrREReqSub.Html = GetHtmlWithDefaultFormat(_report, "SubjectHtml", xrREReqSub.Font);
        }

    }
}
