using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class PurchaseOrderReportDto : PurchaseOrderDto
    {
        public string SupplierAddress { get; set; }
        public string SupplierABN { get; set; }
        public string PoNumberAndSupplier => $"{PoNumber}: {SupplierName}";
        public string PoContactMobile { get; set; }
        public string PoContactNameNumber => $"{PoContactName}{(string.IsNullOrEmpty(PoContactMobile) ? "" : " - " + PoContactMobile)}";

        //Used in report for dummy subreport
        public List<ApprovalListExtDto> ApprovalInList
        {
            get
            {
                if (Approval == null) return null;
                return new List<ApprovalListExtDto>() { Approval };
            }
        }
    }
}
