using cpModel.Dtos.Report;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptClaimCoverPrevPaid : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Progress Claim Summary Prev Paid";
        ProgressClaimVersionReportDto _currVersion;

        /// <summary>
        /// Initializes a new instance of the rptSchedule class.
        /// </summary>
        public rptClaimCoverPrevPaid()
        {
            InitializeComponent();
            ReportTitle = "Progress Claim Summary";
        }

        private void rptClaimCoverPrevPaid_DataSourceRowChanged(object sender, DevExpress.XtraReports.UI.DataSourceRowEventArgs e)
        {
            _currVersion = GetCurrentRow() as ProgressClaimVersionReportDto;
            RecordReference = _currVersion.VersionDescription;
            DataSourceRowChanged += rptClaimCoverPrevPaid_DataSourceRowChanged;
        }

    }
}
