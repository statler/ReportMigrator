using System;
using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.DocRep.ControlledDocs
{
    public partial class rptTransmittal
    {
        public override string BaseReportName { get; set; } = "Transmittal";
        public rptTransmittal()
        {
            InitializeComponent();
            ReportTitle = "Transmittal";
            PageHeader.BeforePrint += PageHeader_BeforePrint;
        }
        private void PageHeader_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var _currTransmittal = GetCurrentRow() as TransmittalReportDto;
            RecordReference = "Transmittal: " + _currTransmittal.TransmittalNo;
        }
    }
}
