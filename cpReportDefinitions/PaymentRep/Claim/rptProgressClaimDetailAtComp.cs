using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptProgressClaimDetailAtComp : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Progress Claim (Forecast)";

        float _descStartWidth = 975;
        const float _descLeft = 0F;
        const float _descIndent = 50F;
        ProgressClaimVersionReportDto _currVersion;

        public rptProgressClaimDetailAtComp()
        {
            InitializeComponent();
            try
            {
                //PrintingSystem.Document.AutoFitToPagesWidth = 1;
                _descStartWidth = lbDesc.WidthF;
            }
            catch (Exception)
            {

            }
            ReportTitle = "Progress Claim (Forecast)";
            DataSourceRowChanged += rptProgressClaimDetail_DataSourceRowChanged;
            Detail_ClaimDetails.BeforePrint += Detail_ClaimDetails_BeforePrint;
        }


        private void Detail_ClaimDetails_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var _currPcd = (sender as DetailBand).Report.GetCurrentRow() as ProgressClaimDetailReportDto;
            if (_currPcd == null) return;
            try
            {
                XRLabel[] lblsTot = new XRLabel[] { lbSchedTotal, lbPCTotal, lbTDTotal, lbTCTotal };
                XRLabel[] lblsNonTot = new XRLabel[] { lbSchedQty, lbUnit, lbSellRate, lbPCQty, lbTDQty, lbTCQty };
                XRLabel[] lblSSi = new XRLabel[] { lbDesc, lbSchedQty, lbTDQty, lbUnit };

                List<XRLabel> lbls = new List<XRLabel>(lblsTot);
                lbls.AddRange(lblsNonTot);

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

                foreach (XRLabel lbl in lblSSi) lbl.ForeColor = fontColor;

                lbDesc.Font = font;
                lbTDQty.Font = font;
                lbUnit.Font = font;

                var lbVisible = !(_currPcd.IsHeading && (_currPcd.TotalToDateEff ?? 0) == 0);
                foreach (XRLabel lbl in lbls) lbl.Visible = lbVisible;
                if (_currPcd.IsSummaryLine)
                {
                    foreach (XRLabel lbl in lbls) lbl.Visible = false;
                    foreach (XRLabel lbl in lblsTot) lbl.Visible = true;
                }

                foreach (XRLabel lbl in lblsTot) lbl.Font = font;

                float leftOS = _descIndent * (_currPcd.Level + (_currPcd.IsSummaryLine ? 1 : 0));
                float sz = Math.Max(_descStartWidth - leftOS, _descStartWidth / 2);
                lbDesc.LeftF = leftOS + _descLeft;
                lbDesc.WidthF = sz;
            }
            catch (Exception)
            {

            }
        }

        private void rptProgressClaimDetail_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currVersion = GetCurrentRow() as ProgressClaimVersionReportDto;
            RecordReference = _currVersion.VersionDescription;
        }
    }
}
