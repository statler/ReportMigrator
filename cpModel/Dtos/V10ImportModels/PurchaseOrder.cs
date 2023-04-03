using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Models.V10ImportModels
{
    public partial class PurchaseOrder
    {
        public Guid UniqueID { get; set; }
        public string HRid { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? PurchaseOrderID { get; set; }
        public int? POIndex { get; set; }
        public string PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public int? Supplier { get; set; }
        public string SupplierContact { get; set; }
        public int? ProjectID { get; set; }
        public bool? isComplete { get; set; }
        public string DeliveryAddress { get; set; }
        public string BillingEntity { get; set; }
        public string BillingAddress { get; set; }
        public string PaymentTerms { get; set; }
        public bool? IsSoftDeleted { get; set; }

    }
}
