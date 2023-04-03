using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class PurchaseOrderReceiptReportDto : PurchaseOrderReportDto
    {
        public List<ReceiptDto> lstReceipts { get; set; }

    }
}
