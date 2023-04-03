using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class PurchaseOrderWithDetailReportDto : PurchaseOrderReportDto
    {
        public List<PurchaseOrderDetailDto> lstPurchaseOrderDetails { get; set; }

    }
}
