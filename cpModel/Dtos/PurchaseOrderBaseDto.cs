using cpModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class PurchaseOrderBaseDto : PurchaseOrderListDto
    {

        public int? ApprovalId { get; set; }
        public Decimal TotalReceipted { get; set; }
        public Decimal TotalInvoiced { get; set; }
        public string SupplierContact { get; set; }
        public DateTime? DateReqd { get; set; }
        public string Comments { get; set; }
        public string Notes { get; set; }
        public string PaymentTerms { get; set; }
        public string ApprovedByName { get; set; }
        public string PoContactName { get; set; }
    }
}
