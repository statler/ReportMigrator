namespace cpReportDefinitions.PaymentRep
{
    public partial class rptMeasureUp : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Quantity Sheet";
        private bool _isMeasureUp = false;
        public bool isMeasureUp
        {
            get
            {
                return _isMeasureUp;
            }
            set
            {
                BaseReportName = ReportTitle = "Measure Up Sheet";
                _isMeasureUp = value;
            }
        }

        public rptMeasureUp()
        {
            InitializeComponent();
            ReportTitle = "Quantity Sheet";
        }

    }
}

