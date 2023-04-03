using cpModel.Dtos.Report;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptClaimCoverACPrevPaid : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Progress Claim Summary (Full)";
        ProgressClaimVersionReportDto _currVersion;

        /// <summary>
        /// Initializes a new instance of the rptSchedule class.
        /// </summary>
        public rptClaimCoverACPrevPaid()
        {
            InitializeComponent();
            ReportTitle = "Progress Claim Summary (Full)";
            DataSourceRowChanged += rptClaimCoverACPrevPaid_DataSourceRowChanged;
        }

        private void rptClaimCoverACPrevPaid_DataSourceRowChanged(object sender, DevExpress.XtraReports.UI.DataSourceRowEventArgs e)
        {
            _currVersion = GetCurrentRow() as ProgressClaimVersionReportDto;
            RecordReference = _currVersion.VersionDescription;
        }

    }
}
