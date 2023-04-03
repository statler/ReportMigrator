using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.ATPRep
{
    public partial class rptATP : rptTemplate
    {
        public override string BaseReportName { get; set; } = "ATP Report";
        AtpReportDto _currRow;

        public rptATP()
        {
            InitializeComponent();
            ReportTitle = "ATP Report";
            DataSourceRowChanged += RptATP_DataSourceRowChanged;
        }

        private void RptATP_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currRow = GetCurrentRow() as AtpReportDto;
            RecordReference = "ATP: " + _currRow.AtpNo;
        }

    }
}
