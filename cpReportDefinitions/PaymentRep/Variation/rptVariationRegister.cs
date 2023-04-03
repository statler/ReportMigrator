namespace cpReportDefinitions.PaymentRep
{
    public partial class rptVariationRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Variation Register";
        public rptVariationRegister()
        {
            InitializeComponent();
            ReportTitle = "Variation Register";
            IsRegisterReport = true;
        }

    }
}
