using cpModel.Dtos.Report;

namespace cpReportDefinitions.PunchlistRep
{
    public partial class rptPunchlistDetail 
    {
        PunchlistReportDto _currPl;
        public override string BaseReportName { get; set; } = "Punchlist Detail";
        public rptPunchlistDetail()
        {
            InitializeComponent();
            ReportTitle = "Punchlist";
            IsRegisterReport = false;
            Detail.BeforePrint += Detail_BeforePrint;
        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _currPl = GetCurrentRow() as PunchlistReportDto;
            RecordReference = $"{_currPl.PunchlistNo}: {_currPl.Description}";
        }
    }
}
