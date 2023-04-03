namespace cpReportDefinitions.PunchlistRep
{
    public partial class rptPunchlistRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Punchlist Register";
        public rptPunchlistRegister()
        {
            InitializeComponent();
            ReportTitle = "Punchlist Register";
            IsRegisterReport = true;

        }
    }
}
