namespace cpReportDefinitions.ConformanceRep
{
    public partial class rptChecklistRegisterByStatus : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Checklist Register by Status";
        public rptChecklistRegisterByStatus()
        {
            InitializeComponent();
            ReportTitle = "Checklist Register by Status";
            IsRegisterReport = true;
        }
    }
}
