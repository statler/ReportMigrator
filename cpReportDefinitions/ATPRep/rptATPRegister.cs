namespace cpReportDefinitions.ATPRep
{
    public partial class rptATPRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "ATP Register";
        public rptATPRegister()
        {
            InitializeComponent();
            ReportTitle = "ATP Register";
            IsRegisterReport = true;
        }
    }
}
