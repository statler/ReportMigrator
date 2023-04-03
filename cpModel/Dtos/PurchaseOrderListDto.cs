using System;

namespace cpModel.Dtos
{
    public class PurchaseOrderListDto
    {
        public int PurchaseOrderId { get; set; }
        public int? PoIndex { get; set; }
        public string PoNumber { get; set; }
        public DateTime? PoDate { get; set; }
        public int? RaisedById { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool? IsComplete { get; set; }
        public string DeliveryAddress { get; set; }
        public string BillingAddress { get; set; }

        //Projected
        public string RaisedByName { get; set; }
        public string SupplierName { get; set; }
        public Decimal PoValue { get; set; }
        public string Status { get; set; }

    }
}
