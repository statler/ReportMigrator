namespace cpReportDefinitions.LotReport
{
    public partial class rptLotRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Lot Register";
        public rptLotRegister()
        {
            InitializeComponent();
            ReportTitle = "Lot Register";
            IsRegisterReport = true;
        }

    }
}
