using cpModel.Dtos.Report;
using cpModel.Helpers;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptVariationEstimate : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Variation Estimate";
        public rptVariationEstimate()
        {
            InitializeComponent();
            ReportTitle = "Variation Estimate";
            Detail_VariationEst.BeforePrint += Detail_VariationEst_BeforePrint;
            DetailReport_VariationEst.BeforePrint += DetailReport_VariationEst_BeforePrint;
            Detail.BeforePrint += Detail_BeforePrint;
            sbNotes.BeforePrint += sbNotes_BeforePrint;
            sbDetail.BeforePrint += sbDetail_BeforePrint;
            xrrtDetail.BeforePrint += XrrtDetail_BeforePrint;
            xrrtVariationEstimateDescription.BeforePrint += XrrtVariationEstimateDescription_BeforePrint;
            DataSourceRowChanged += rpt_DataSourceRowChanged;
        }


        private void rpt_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            var _currVrn = GetCurrentRow() as VariationReportDto;
            RecordReference = "VRN: " + _currVrn.VariationNo;
        }

        private void XrrtVariationEstimateDescription_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            xrrtVariationEstimateDescription.Html = GetHtmlWithDefaultFormat(_report, "Description", xrrtVariationEstimateDescription.Font);
        }

        private void XrrtDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            xrrtDetail.Html = GetHtmlWithDefaultFormat(_report, "Detail", xrrtDetail.Font);
        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var v = (VariationReportDto)GetCurrentRow();
            if (v != null) lbEstimatedQty.Text = $"Variation valuation for qty of {v.QtyEstimated: #,###,##0.###} {v.Unit} (Rate={v.SellRateSubmitted:C2})";
        }

        private void Detail_VariationEst_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase rep = (sender as DetailBand).Report;
            var v = (VariationEstimateReportDto)rep.GetCurrentRow();
            if (v == null) return;
            lbQty.Visible = !v.isHeading;
            lbUnit.Visible = !v.isHeading;
            lbSellRate.Visible = !v.isHeading;
            lbTotal.Visible = !v.isHeading;
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

        private void DetailReport_VariationEst_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var v = (VariationReportDto)GetCurrentRow();
            if (v.Estimates.Count == 0) e.Cancel = true;
        }
    }
}
