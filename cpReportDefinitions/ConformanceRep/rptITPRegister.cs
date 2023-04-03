namespace cpReportDefinitions.ConformanceRep
{
    public partial class rptITPRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "ITP Register";

        public rptITPRegister()
        {
            InitializeComponent();
            ReportTitle = "ITP Register";
            IsRegisterReport = true;
        }

    }
}
