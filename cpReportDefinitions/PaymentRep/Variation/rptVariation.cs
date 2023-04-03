using cpModel.Dtos.Report;
using cpModel.Helpers;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptVariation : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Variation Summary";

        public rptVariation()
        {
            InitializeComponent();
            ReportTitle = "Variation Summary";
            Detail_Photo.BeforePrint += Detail_Photo_BeforePrint;
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
            xrrtVariationEstimateDescription.Html = GetHtmlWithDefaultFormat(_report, "Detail", xrrtVariationEstimateDescription.Font);
        }

        private void XrrtDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            xrrtDetail.Html = GetHtmlWithDefaultFormat(_report, "Description", xrrtDetail.Font);
        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var v = (VariationReportDto)GetCurrentRow();
            if (v != null) lbEstimatedQty.Text = $"Variation valuation for qty of {v.QtyEstimated: #,###,##0.###} {v.Unit} (Rate={v.SellRateSubmitted:C2})";
        }

        private void sbNotes_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var v = (VariationReportDto)GetCurrentRow();
            if (string.IsNullOrWhiteSpace(v.Notes))
                e.Cancel = true;
        }

        private void sbDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var v = (VariationReportDto)GetCurrentRow();
            if (string.IsNullOrWhiteSpace(_richEditProcessor.GetPlainTextFromHTML(v.Detail)))
                e.Cancel = true;
        }

        private void Detail_Photo_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase r = (sender as DetailBand).Report;

            try
            {
                var np = (PhotoVariationReportDto)r.GetCurrentRow();
                if (np != null && np.PhotoId != null)
                {
                    GetPhotoById(img, np.PhotoId.Value);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
