using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.ConformanceRep
{
    public partial class rptApproval : rptTemplate
    {
        ApprovalReportDto _currApproval;
        public override string BaseReportName { get; set; } = "Approval Report";

        public rptApproval()
        {
            InitializeComponent();
            ReportTitle = "Approval Report";
            DataSourceRowChanged += rptApproval_DataSourceRowChanged;
            PageHeader.BeforePrint += PageHeader_BeforePrint;
            rtBodyHtml.BeforePrint += rtBodyHtml_BeforePrint;
            xrWorkflowComment.BeforePrint += xrWorkflowComment_BeforePrint;
            xrREReqSub.BeforePrint += xrREReqSub_BeforePrint;
        }

        private void rptApproval_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currApproval = GetCurrentRow() as ApprovalReportDto;
            RecordReference = "Approval: " + _currApproval.ApprovalNo;
        }

        private void PageHeader_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _currApproval = GetCurrentRow() as ApprovalReportDto;
            RecordReference = "Approval: " + _currApproval.ApprovalNo;
        }

        private void xrREReqSub_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            xrREReqSub.Html = GetHtmlWithDefaultFormat(_report, "SubjectHtml", xrREReqSub.Font);
        }

        private void rtBodyHtml_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            rtBodyHtml.Html = GetHtmlWithDefaultFormat(_report, "BodyHtml", rtBodyHtml.Font);
        }

        private void xrWorkflowComment_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase logReport = (sender as XRRichText).Band.Report;
            xrWorkflowComment.Html = GetHtmlWithDefaultFormat(logReport, "LogCommentHtml", xrWorkflowComment.Font);
        }
    }
}
