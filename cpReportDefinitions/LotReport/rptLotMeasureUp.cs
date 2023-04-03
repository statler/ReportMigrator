using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.LotReport
{
    public partial class rptLotMeasureUp : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Quantity Sheet for Lot";

        private bool _isMeasureUp = false;
        LotReportDto _currLot;
        public bool IsMeasureUp
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

        public rptLotMeasureUp()
        {
            InitializeComponent();
            ReportTitle = "Quantity Sheet";
            DataSourceRowChanged += rptLotMeasureUp_DataSourceRowChanged;
            BeforePrint += rptLotMeasureUp_BeforePrint;
        }


        private void rptLotMeasureUp_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            _currLot = GetCurrentRow() as LotReportDto;
            RecordReference = "Lot: " + _currLot.LotNumber;
        }

        private void rptLotMeasureUp_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isMeasureUp)
            {
                lbQty.DataBindings.Clear();
                lbEffQty.DataBindings.Clear();
                lbQty.ExpressionBindings.Clear();
                lbEffQty.ExpressionBindings.Clear();
                lbQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
                lbEffQty.Borders = DevExpress.XtraPrinting.BorderSide.All;
                ReportTitle = "Measure Up Sheet";
            }

        }
    }
}
