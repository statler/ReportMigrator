namespace cpReportDefinitions.CostRep
{
    public partial class rptPORegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Purchase Order Register";
        public rptPORegister()
        {
            InitializeComponent();
            IsInternalReport = true;
            IsRegisterReport = true;
            ReportTitle = "Purchase Order Register";
        }


        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void ReportFooter_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
