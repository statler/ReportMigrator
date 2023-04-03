namespace cpReportDefinitions.ATPRep
{
    public partial class rptATPSummary : rptTemplate
    {
        public override string BaseReportName { get; set; } = "ATP Summary";


        public rptATPSummary()
        {
            InitializeComponent();
            ReportTitle = "ATP Summary";
            IsRegisterReport = true;
        }
    }
}
