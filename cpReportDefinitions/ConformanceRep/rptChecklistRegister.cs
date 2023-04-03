namespace cpReportDefinitions.ConformanceRep
{
    public partial class rptChecklistRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Checklist Register";
        public rptChecklistRegister()
        {
            InitializeComponent();
            ReportTitle = "Checklist Register";
            IsRegisterReport = true;
        }
    }
}
