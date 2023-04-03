using cpModel.Dtos;
using cpModel.Dtos.Report;
using cpModel.Enums;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace cpReportDefinitions.NCRRep
{
    public partial class rptNCRManual : rptTemplate, IReportOptions
    {
        public override string BaseReportName { get; set; } = "NCR Report";

        NcrReportDto _currNCR;

        public int ShowOptions { get; set; }

        public rptNCRManual()
        {
            InitializeComponent();
            ReportTitle = "NCR Report";
            PrintingSystem.Document.AutoFitToPagesWidth = 1;
            Detail.BeforePrint += Detail_BeforePrint;
            PageHeader.BeforePrint += PageHeader_BeforePrint;
            DetailReport_Lots.BeforePrint += DetailReport_Lots_BeforePrint;
            DataSourceRowChanged += rptNCRElect_DataSourceRowChanged;
            BeforePrint += rptNCRElect_BeforePrint;
            Detail_Photo.BeforePrint += Detail_Photo_BeforePrint;
            Detail_Lot.BeforePrint += Detail_Lot_BeforePrint;
            xrApproval.BeforePrint += (s, e) => RichEditInBand_Master_BeforePrint(s, e, "ApprovalDetails");
            xrCloseout.BeforePrint += (s, e) => RichEditInBand_Master_BeforePrint(s, e, "CloseOutDetails");
        }


        private void rptNCRElect_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ShouldIgnoreOptions) return;
            if (sbRootCause != null) sbRootCause.Visible = HasFlag(ShowOptions, (int)ReportEnums.NCRprintOption.showRootCause);
            if (sbCloseout != null) sbCloseout.Visible = HasFlag(ShowOptions, (int)ReportEnums.NCRprintOption.showCloseOut);
            if (DetailReport_Photo != null) DetailReport_Photo.Visible = HasFlag(ShowOptions, (int)ReportEnums.NCRprintOption.showPhotos);
        }

        private void Detail_Photo_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase r = (sender as DetailBand).Report;
            if (r == null) return;

            try
            {
                PhotoNcrDto np = (PhotoNcrDto)r.GetCurrentRow();

                if (np != null && np.PhotoId != null)
                {
                    GetPhotoById(img, np.PhotoId.Value);
                }
            }
            catch (Exception)
            {
            }
        }

        private void sbRootCause_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currNCR.RootCauseInclCategory)) e.Cancel = true;
        }

        private void rptNCRElect_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currNCR = GetCurrentRow() as NcrReportDto;
            RecordReference = "NCR: " + _currNCR.NcrNo;
        }

        private void PageHeader_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _currNCR = GetCurrentRow() as NcrReportDto;
            RecordReference = "NCR: " + _currNCR.NcrNo;
        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //cbIncidental.Checked = (_currNCR.Severity == 1);
            //cbMinor.Checked = (_currNCR.Severity == 2);
            //cbMajor.Checked = (_currNCR.Severity == 3);
            //cbRetest.Checked = (_currNCR.ActionType == 1);
            //cbRepair.Checked = (_currNCR.ActionType == 2);
            //cbReplace.Checked = (_currNCR.ActionType == 3);
            //cbReject.Checked = (_currNCR.ActionType == 4);
            //cbUseAsIs.Checked = (_currNCR.ActionType == 5);
            //cbOther.Checked = (_currNCR.ActionType == 6);
            //cbNo.Checked = (_currNCR.ThirdPartyAppReqd == 0);
            //cbYes.Checked = (_currNCR.ThirdPartyAppReqd == 1);
        }

        private void DetailReport_Lots_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            lbhRPF.Visible = false;
            lbRPValue.Visible = false;
        }

        private void Detail_Lot_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase r = (sender as DetailBand).Report;
            if (r == null) return;
            LotBasicReportDto l = (LotBasicReportDto)r.GetCurrentRow();
            if (l != null && l.RpValue != 0)
            {
                lbRPValue.Visible = true;
                lbhRPF.Visible = true;
            }
            else lbRPValue.Visible = false;
        }


    }
}
