using System;
using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.DocRep.ControlledDocs
{
    public partial class rptTransmittalReg
    {
        public override string BaseReportName { get; set; } = "Transmittal Register";
        public rptTransmittalReg()
        {
            InitializeComponent();
            ReportTitle = "Transmittal Register";
            PageHeader.BeforePrint += PageHeader_BeforePrint;
        }
        private void PageHeader_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var _currTransmittal = GetCurrentRow() as TransmittalReportDto;
            RecordReference = "Transmittal Register " + _currTransmittal.TransmittalNo;
        }
    }
}
