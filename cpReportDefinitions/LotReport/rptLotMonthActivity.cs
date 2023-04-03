namespace cpReportDefinitions.LotReport
{
    public partial class rptLotMonthActivity : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Lot Month Activity";

        public rptLotMonthActivity()
        {
            InitializeComponent();
            ReportTitle = "Monthly activity";
            BeforePrint += rptSchedule_BeforePrint;
        }


        private void rptSchedule_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DataSource == null) e.Cancel = true;
        }

    }
}
