namespace cpReportDefinitions.TestReqRep
{
    public partial class rptTestReqRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Test Request Register";

        public rptTestReqRegister()
        {
            InitializeComponent();
            ReportTitle = "Test Request Register";
            IsRegisterReport = true;
        }
    }
}
