using cpModel.Dtos.Report;
using cpShared.Extensions;
using DevExpress.XtraReports.UI;
using System;

namespace cpReportDefinitions.LotReport
{
    public partial class rptConfGuarReport
    {
        LotReportDto _currLot;
        public override string BaseReportName { get; set; } = "Conformance Declaration";

        public rptConfGuarReport()
        {
            InitializeComponent();
            ReportTitle = "Conformance Declaration";
            IsRegisterReport = true;
            DataSourceRowChanged += rptConfGuarReport_DataSourceRowChanged;
            ghStatus.BeforePrint += ghStatus_BeforePrint;
            Detail.BeforePrint += Detail_BeforePrint;
        }


        private void rptConfGuarReport_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currLot = GetCurrentRow() as LotReportDto;
        }

        private void ghStatus_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            switch (_currLot.LotStatus.ToLower())
            {
                case "open":
                    lbStatusDateHead.Text = "";
                    break;
                case "guaranteed":
                    lbStatusDateHead.Text = "Guar. Date";
                    break;
                case "conformed":
                    lbStatusDateHead.Text = "Conf. Date";
                    break;
                case "rejected":
                    lbStatusDateHead.Text = $"{DateRejectedString}. Date";
                    break;
            }

        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DateTime? DateToUse = null;
            switch (_currLot.LotStatus.ToLower())
            {
                case "open":
                    DateToUse = _currLot.DateOpen;
                    break;
                case "guaranteed":
                    DateToUse = _currLot.DateGuar;
                    break;
                case "conformed":
                    DateToUse = _currLot.DateConf;
                    break;
                case "rejected":
                    DateToUse = _currLot.DateRejected;
                    break;
            }
            lbStatusDate.Text = DateToUse == null ? "" : string.Format("{0:d/MM/yyyy}", DateToUse);

        }
    }
}
