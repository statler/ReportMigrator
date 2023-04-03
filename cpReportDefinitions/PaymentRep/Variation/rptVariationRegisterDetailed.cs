using cpModel.Dtos.Report;
using cpModel.Helpers;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptVariationRegisterDetailed : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Variation Register (Detailed)";
        public rptVariationRegisterDetailed()
        {
            InitializeComponent();
            ReportTitle = "Variation Register (Detailed)";
            IsRegisterReport = true;
            xrrtDetail.BeforePrint += XrrtDetail_BeforePrint;
            sbDetail.BeforePrint += sbDetail_BeforePrint;
            sbNotes.BeforePrint += sbNotes_BeforePrint;
        }

        private void XrrtDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            xrrtDetail.Html = GetHtmlWithDefaultFormat(_report, "Detail", xrrtDetail.Font);
        }


        private void sbDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var v = (VariationReportDto)GetCurrentRow();
            if (string.IsNullOrWhiteSpace(_richEditProcessor.GetPlainTextFromHTML(v.Detail)))
                e.Cancel = true;
        }

        private void sbNotes_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var v = (VariationReportDto)GetCurrentRow();
            if (string.IsNullOrWhiteSpace(v.Notes))
                e.Cancel = true;
        }
    }
}
