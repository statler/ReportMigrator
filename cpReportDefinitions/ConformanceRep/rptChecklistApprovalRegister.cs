using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.ConformanceRep
{
    public partial class rptChecklistApprovalRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Checklist Approval Status";

        public rptChecklistApprovalRegister()
        {
            InitializeComponent();
            ReportTitle = "Checklists With Approvals";
            IsRegisterReport = true;
            xrrtLotItpDetailDesc.BeforePrint += xrrtLotItpDetailDesc_BeforePrint;
        }

        private void xrrtLotItpDetailDesc_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase _report = (sender as XRRichText).Band.Report;
            xrrtLotItpDetailDesc.Html = GetHtmlWithDefaultFormat(_report, "Description", xrrtLotItpDetailDesc.Font);
        }
    }
}
