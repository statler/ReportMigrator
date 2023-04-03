namespace cpReportDefinitions.SecurityRep
{
    public partial class rptRegisterAccess : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Register Access Summary";

        public rptRegisterAccess()
        {
            InitializeComponent();
            ReportTitle = "Register Access Summary";
        }

    }
}
