using System;

namespace cpModel.Dtos
{
    public class PurchaseOrderDetailImportDto
    {
        public int? PurchaseOrderID { get; set; }
        public decimal ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public bool IsRateOnly { get; set; }
        public decimal Qty { get; set; }
        public string Unit { get; set; }
        public decimal Rate { get; set; }
        public string Notes { get; set; }
        public decimal GSTRate { get; set; }
        public int? ResType { get; set; }
        public int? CostCodeId { get; set; }
    }
}
