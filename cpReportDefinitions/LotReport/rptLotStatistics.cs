namespace cpReportDefinitions.LotReport
{
    public partial class rptLotStatistics : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Lot Summary";

        public rptLotStatistics()
        {
            InitializeComponent();
            ReportTitle = "Lot Summary Report";
            PageHeader.BeforePrint += PageHeader_BeforePrint;
        }


        int i = 1;
        private void PageHeader_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (i > 1)
            {
                FindControl("lbFilter").Visible = false;
                FindControl("lbFiltHead").Visible = false;
            }
            i++;
        }

    }
}
