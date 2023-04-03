using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.ConformanceRep
{
    public partial class rptApprovalRegisterDetail : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Approval Register (Detail)";

        public rptApprovalRegisterDetail()
        {
            InitializeComponent();
            ReportTitle = "Approval Register";
            IsRegisterReport = true;
            xrREReqSub.BeforePrint += xrREReqText_BeforePrint;
            xrWorkflowComment.BeforePrint += XrWorkflowComment_BeforePrint;
        }

        private void XrWorkflowComment_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            xrWorkflowComment.Html = GetHtmlWithDefaultFormat(_report, "LogCommentHtml", xrWorkflowComment.Font);
        }

        private void xrREReqText_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            xrREReqSub.Html = GetHtmlWithDefaultFormat(_report, "SubjectHtml", xrREReqSub.Font);
        }

    }
}
