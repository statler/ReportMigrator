using cpModel.Dtos.Report;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptClaimCoverAC : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Progress Claim Summary (At Comp)";
        ProgressClaimVersionReportDto _currVersion;

        /// <summary>
        /// Initializes a new instance of the rptSchedule class.
        /// </summary>
        public rptClaimCoverAC()
        {
            InitializeComponent();
            ReportTitle = "Progress Claim Summary (At Comp)";
            DataSourceRowChanged += rptClaimCoverAC_DataSourceRowChanged;
        }

        private void rptClaimCoverAC_DataSourceRowChanged(object sender, DevExpress.XtraReports.UI.DataSourceRowEventArgs e)
        {
            _currVersion = GetCurrentRow() as ProgressClaimVersionReportDto;
            RecordReference = _currVersion.VersionDescription;
        }

    }
}
