namespace cpReportDefinitions.NCRRep
{
    public partial class rptNCRRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "NCR Register";

        public rptNCRRegister()
        {
            InitializeComponent();
            ReportTitle = "NCR Register";
            IsRegisterReport = true;
        }

    }
}
