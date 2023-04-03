using cpModel.Dtos.Report;
using cpModel.Helpers;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptVariationValuationDJC : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Variation Valuation (Markup)";
        public rptVariationValuationDJC()
        {
            InitializeComponent();
            IsInternalReport = true;
            ReportTitle = "Variation Valuation (Markup)";
            xrrtDetail.BeforePrint += XrrtDetail_BeforePrint;
            xrrtVariationEstimateDescription.BeforePrint += XrrtVariationEstimateDescription_BeforePrint;
            Detail.BeforePrint += Detail_BeforePrint;
            Detail_VariationEst.BeforePrint += Detail_VariationEst_BeforePrint;
            sbDetail.BeforePrint += sbDetail_BeforePrint;
            DetailReport_VariationEst.BeforePrint += DetailReport_VariationEst_BeforePrint;
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
            DetailBand d = sender as DetailBand;
            var v = (VariationEstimateReportDto)d.Report.GetCurrentRow();

            if (v == null) return;

            bool isControlVisible = !((v.Qty == 0) && (v.SellRate == 0));
            lbQty.Visible = isControlVisible;
            lbRate.Visible = isControlVisible;
            lbSell.Visible = isControlVisible;
            lbUnit.Visible = isControlVisible;
            lbTotal.Visible = isControlVisible;
            lbMup.Visible = isControlVisible;
        }

        private void sbDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var v = (VariationReportDto)GetCurrentRow();
            if (string.IsNullOrWhiteSpace(_richEditProcessor.GetPlainTextFromHTML(v.Detail)))
                e.Cancel = true;
        }

        private void DetailReport_VariationEst_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var v = (VariationReportDto)GetCurrentRow();
            if (v.Estimates.Count == 0) e.Cancel = true;
        }
    }
}
