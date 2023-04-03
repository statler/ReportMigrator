using cpModel.Dtos.Report;
using cpModel.Enums;
using cpModel.Helpers;
using DevExpress.XtraReports.UI;
using System;
using DevExpress.XtraRichEdit;

namespace cpReportDefinitions.ConformanceRep
{
    public partial class rptITP : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Inspection Test Plan";
        ItpReportDto _currITP;
        int _detailCount = 0;
        int _testCount = 0;
        float _descWidthDefault = 0;
        bool _isCurrentDetailHeader = false;

        public rptITP()
        {
            InitializeComponent();
            ReportTitle = "Inspection Test Plan";
            _descWidthDefault = xrrtDescription.WidthF;
            PageFooter.BeforePrint += PageFooter_BeforePrint;
            ITPDetail_Detail.BeforePrint += ITPDetail_Detail_BeforePrint;
            TestingReport_Detail.BeforePrint += TestingReport_Detail_BeforePrint;
            TestingReport_ReportHeader.BeforePrint += TestingReport_ReportHeader_BeforePrint;
            TestingReport_ReportFooter.BeforePrint += TestingReport_ReportFooter_BeforePrint;
            DataSourceRowChanged += rptITP_DataSourceRowChanged;
            if (IsDesktop) PrintingSystem.Document.AutoFitToPagesWidth = 1;
        }

        private void TestingReport_ReportFooter_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isCurrentDetailHeader) xrLine1.ForeColor = System.Drawing.Color.Black;
            else xrLine1.ForeColor = System.Drawing.Color.LightGray;
        }

        private void PageFooter_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DateTime? revDate = _currITP.RevisionDate;
            string rev = _currITP.RevisionId == null ? "" : _currITP.RevisionId.ToString();

            string RevisionDate = revDate != null && revDate != DateTime.MinValue ? String.Format("{0:dd/MM/yyyy}", revDate) : "No Date";
            lblFtrCenterText.Text = String.Format("Revision: {0} - {1}", rev, RevisionDate);
        }

        private void rptITP_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _detailCount = 0;
            _currITP = GetCurrentRow() as ItpReportDto;
            RecordReference = "ITP: " + _currITP.InstanceDescription;
        }


        private void ITPDetail_Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase detailSubReport = (sender as DetailBand).Report;
            ItpDetailReportDto det = detailSubReport.GetCurrentRow() as ItpDetailReportDto;
            if (det == null)
            {
                e.Cancel = true;
                return;
            }

            //Header records take up the full row, and are shown by hiding/viewing the different bands.
            _isCurrentDetailHeader = det.ItemTypeEnum == ItpItemTypeEnum.Heading || (string.IsNullOrEmpty(det.ItemTypeString) && string.IsNullOrEmpty(det.Responsibility)
                          && string.IsNullOrEmpty(det.Records) && string.IsNullOrEmpty(det.InspMeth) && string.IsNullOrEmpty(det.Clause));

            sbHeading.Visible = _isCurrentDetailHeader;
            sbItem.Visible = !_isCurrentDetailHeader;

            var HtmlControlDesc = _isCurrentDetailHeader ? xrrtHeading : xrrtDescription;

            //Hide headings if label has no content.
            lbhResp.Visible = !String.IsNullOrEmpty(det.Responsibility);
            lbhRecords.Visible = !String.IsNullOrEmpty(det.Records);
            lbhMethodInsp.Visible = !String.IsNullOrEmpty(det.InspMeth);
            lbhClause.Visible = !String.IsNullOrEmpty(det.Clause);
            lbResp.Visible = !String.IsNullOrEmpty(det.Responsibility);
            lbRecords.Visible = !String.IsNullOrEmpty(det.Records);
            lbMethodInsp.Visible = !String.IsNullOrEmpty(det.InspMeth);
            lbClause.Visible = !String.IsNullOrEmpty(det.Clause);

            var plainRef = _richEditProcessor.GetPlainTextFromHTML(det.ReferenceText);
            _richEditProcessor.RichEditServer.Document.HtmlText = det.Description;
            if (!string.IsNullOrWhiteSpace(plainRef))
            {
                if (string.IsNullOrWhiteSpace(_richEditProcessor.RichEditServer.Document.Text)) _richEditProcessor.RichEditServer.Document.HtmlText = det.ReferenceText;
                else  _richEditProcessor.RichEditServer.Document.InsertHtmlText(_richEditProcessor.RichEditServer.Document.Range.Start, det.ReferenceText + "<br>");
            }
            string originalHTML = _richEditProcessor.RichEditServer.Document.HtmlText;
            string amendedHTMLDesc = _richEditProcessor.ChangeHTMLFontNameAndSize(HtmlControlDesc.Font, originalHTML);
            if (HtmlControlDesc != null) HtmlControlDesc.Html = amendedHTMLDesc;

            //Do not increment the detail count for a header record.
            if (!_isCurrentDetailHeader) _detailCount++;
            lbDetailNo.Text = _detailCount.ToString();
            (sender as DetailBand).Height = 0;
        }

        private void TestingReport_ReportHeader_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _testCount = 0;
            XtraReportBase testSubReport = (sender as ReportHeaderBand).Report;
            if (testSubReport.GetCurrentRow() == null)
            {
                e.Cancel = true;
                return;
            }
        }

        private void TestingReport_Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase testSubReport = (sender as DetailBand).Report;
            if (testSubReport.GetCurrentRow() == null)
            {
                e.Cancel = true;
                return;
            }

            ItpTestReportDto currITPDetailTest = testSubReport.GetCurrentRow() as ItpTestReportDto;
            cbIsOptional.Visible = currITPDetailTest.IsOptional ?? false;
            cbIsOrSet.Visible = currITPDetailTest.IsOrSet;
            _testCount++;
            lblIndex.Text = _detailCount + "-" + _testCount;
            string originalHTML = currITPDetailTest.Compliance;
            string amendedHTMLDesc = _richEditProcessor.ChangeHTMLFontNameAndSize(xrrtCompliance.Font, originalHTML);
            if (xrrtCompliance != null) xrrtCompliance.Html = amendedHTMLDesc;
        }
    }
}
