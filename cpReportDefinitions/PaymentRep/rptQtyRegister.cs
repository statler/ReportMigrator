using cpModel.Dtos.Report;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.PaymentRep
{
    public partial class rptQtyRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Quantity Summary By Schedule";
        public rptQtyRegister()
        {
            InitializeComponent();
            ReportTitle = "Quantity Summary By Schedule";
            Detail.BeforePrint += Detail_BeforePrint;
        }


        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var band = (sender as DetailBand);
            var row = band.Report.GetCurrentRow() as LotQuantityReportDto;
            if (row.LotId == null) band.StyleName = "styleFloat";
            else if (row.Status == "Conformed") band.StyleName = "styleConformed";
            else if (row.Status == "Guaranteed") band.StyleName = "styleGuaranteed";
            else if (row.Status == DateRejectedString) band.StyleName = "styleRejected";
            else band.StyleName = "styleOpen";
        }
    }
}
