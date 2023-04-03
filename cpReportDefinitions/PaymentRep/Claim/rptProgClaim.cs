
using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;
using System;
using System.Drawing;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptProgClaim : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Progress Claim";
        float _descStartWidth = 975;
        const float _descLeft = 0F;
        const float _descIndent = 50F;
        ProgressClaimVersionReportDto _currVersion;

        public rptProgClaim()
        {
            InitializeComponent();
            try
            {
                _descStartWidth = lbDesc.WidthF;
            }
            catch (Exception)
            {

            }
            ReportTitle = "Progress Claim";
            DataSourceRowChanged += rptProgClaim_DataSourceRowChanged;
            PageHeader.BeforePrint += PageHeader_BeforePrint;
            Detail_ClaimDetail.BeforePrint += Detail_ClaimDetail_BeforePrint;
        }


        private void Detail_ClaimDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var _currPcd = (sender as DetailBand).Report.GetCurrentRow() as ProgressClaimDetailReportDto;
            if (_currPcd == null) return;
            try
            {
                XRLabel[] lbls = new XRLabel[] { lbSchedQty, lbClaimQty, lbUnit, lbSellRate, lbSellTotal };
                XRLabel[] lblSSi = new XRLabel[] { lbDesc, lbSchedQty, lbClaimQty, lbUnit };

                Font font = new Font(lbDesc.Font, FontStyle.Regular);
                if (_currPcd.IsHeading || _currPcd.IsSummaryLine)
                {
                    if (_currPcd.Level == 0) font = new Font(font, FontStyle.Bold);
                    if (_currPcd.Level == 1) font = new Font(font, FontStyle.Underline);
                }
                if (_currPcd.IsSummaryLine)
                {
                    font = new Font(font, font.Style | FontStyle.Italic);

                }
                Color fontColor = Color.Black;
                //if (currSI.lineType == FlatSchedule.LineType.SnapshotItem || currSI.lineType == FlatSchedule.LineType.SnapshotHeading)
                //{
                //    font = new Font(font, font.Style | FontStyle.Italic);
                //    fontColor = Color.Gray;
                //}

                foreach (XRLabel lbl in lblSSi) lbl.ForeColor = fontColor;

                lbDesc.Font = font;
                lbClaimQty.Font = font;
                lbUnit.Font = font;

                var lbVisible = !(_currPcd.IsHeading && (_currPcd.TotalToDateEff ?? 0) == 0);
                foreach (XRLabel lbl in lbls) lbl.Visible = lbVisible;
                if (_currPcd.IsSummaryLine)
                {
                    foreach (XRLabel lbl in lbls) lbl.Visible = false;
                    lbSellTotal.Visible = true;
                }

                lbSellTotal.Font = font;

                float leftOS = _descIndent * (_currPcd.Level + (_currPcd.IsSummaryLine ? 1 : 0));
                float sz = Math.Max(_descStartWidth - leftOS, _descStartWidth / 2);
                lbDesc.LeftF = leftOS + _descLeft;
                lbDesc.WidthF = sz;
            }
            catch (Exception)
            {

            }
        }

        private void rptProgClaim_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currVersion = GetCurrentRow() as ProgressClaimVersionReportDto;
            RecordReference = _currVersion.VersionDescription;
        }

        private void PageHeader_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //_currVersion = GetCurrentRow() as ProgressClaimVersionReportDto;
            //RecordReference = "Progress Claim: " + _currVersion.VersionDescription;
        }
    }
}
