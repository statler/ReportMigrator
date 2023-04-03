namespace cpReportDefinitions.SurveyRep
{
    public partial class rptSurveyRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Survey Register";

        public rptSurveyRegister()
        {
            InitializeComponent();
            ReportTitle = "Survey Register";
            IsRegisterReport = true;
        }
    }
}
