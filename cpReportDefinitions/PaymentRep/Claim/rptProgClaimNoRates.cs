using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;
using System;
using System.Drawing;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptProgClaimNoRates : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Progress Claim (with qty)";

        float _descStartWidth = 975;
        float _ssDescStartWidth = 975;
        const float _descLeft = 0F;
        const float _descIndent = 50F;
        ProgressClaimVersionReportDto _currVersion;
        ProgressClaimDetailReportDto _currPcd;

        public rptProgClaimNoRates()
        {
            InitializeComponent();
            try
            {
                _descStartWidth = lbDesc.WidthF;
                _ssDescStartWidth = lbSsDesc.WidthF;
            }
            catch (Exception)
            {

            }
            ReportTitle = "Progress Claim (with qty)";
            DataSourceRowChanged += rptProgClaim_DataSourceRowChanged;
            GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
            PageHeader.BeforePrint += PageHeader_BeforePrint;
            Detail_ClaimDetail.BeforePrint += Detail_ClaimDetail_BeforePrint;
            Detail_Snapshot.BeforePrint += Detail_Snapshot_BeforePrint;
        }


        private void Detail_ClaimDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _currPcd = (sender as DetailBand).Report.GetCurrentRow() as ProgressClaimDetailReportDto;
            if (_currPcd == null) return;
            try
            {
                XRLabel[] lbls = new XRLabel[] { lbSchedQty, lbClaimQty, lbUnit };
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

        private void Detail_Snapshot_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                float leftOS = _descIndent * (_currPcd.Level + 1);
                float sz = Math.Max(_ssDescStartWidth - leftOS, _ssDescStartWidth / 2);
                lbSsDesc.LeftF = leftOS + _descLeft;
                lbSsDesc.WidthF = sz;
            }
            catch (Exception)
            {

            }
        }

        private void GroupHeader1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                float leftOS = _descIndent * (_currPcd.Level + 1);
                float sz = Math.Max(_ssDescStartWidth - leftOS, _ssDescStartWidth / 2);
                lbStatusText.LeftF = leftOS + _descLeft;
                lbStatusText.WidthF = sz;
            }
            catch (Exception)
            {

            }
        }
    }
}
