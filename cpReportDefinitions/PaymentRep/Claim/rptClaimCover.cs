using cpModel.Dtos.Report;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptClaimCover : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Progress Claim Summary";
        ProgressClaimVersionReportDto _currVersion;

        /// <summary>
        /// Initializes a new instance of the rptSchedule class.
        /// </summary>
        public rptClaimCover()
        {
            InitializeComponent();
            ReportTitle = "Progress Claim Summary";
            DataSourceRowChanged += rptClaimCoverAC_DataSourceRowChanged;
        }

        private void rptClaimCoverAC_DataSourceRowChanged(object sender, DevExpress.XtraReports.UI.DataSourceRowEventArgs e)
        {
            _currVersion = GetCurrentRow() as ProgressClaimVersionReportDto;
            RecordReference = _currVersion.VersionDescription;
        }

    }
}
