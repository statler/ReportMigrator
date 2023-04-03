using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Models.V10ImportModels
{
    public class PurchaseOrderDetail
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int PoDetailId { get; set; }
        public int? PurchaseOrder { get; set; }
        public decimal? ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public bool? IsRateOnly { get; set; }
        public decimal? Qty { get; set; }
        public string Unit { get; set; }
        public decimal? Rate { get; set; }
        public string Notes { get; set; }
        public decimal? GstRate { get; set; }
        public int? ResType { get; set; }
        public int? CostCodeId { get; set; }
    }
}
