using cpModel.Dtos;
using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.CostRep
{
    public partial class rptPOReceipts : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Purchase Order Receipts";
        public rptPOReceipts()
        {
            InitializeComponent();
            ReportTitle = "Purchase Order Receipts";
            IsRegisterReport = true;
            IsInternalReport = true;
            ReceiptDetail.BeforePrint += ReceiptDetail_BeforePrint;
        }

        private void ReceiptDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XtraReportBase rep = (sender as DetailBand).Report;
            var row = rep.GetCurrentRow();
            e.Cancel = (row == null || ((row as ReceiptDto).ReceiptDate == null));
        }
    }
}
