using System;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.DocRep.ContractNotices
{
    public partial class rptContractNoticeReg
    {
        public override string BaseReportName { get; set; } = "Contract Notice Register";
        public rptContractNoticeReg()
        {
            InitializeComponent();
            ReportTitle = "Contract Notice Register";
            IsRegisterReport = true;
        }

        private void RtfDescription_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
