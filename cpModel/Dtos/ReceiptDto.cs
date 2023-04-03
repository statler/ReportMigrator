using System;

namespace cpModel.Dtos
{
    public class ReceiptDto
    {
        public int ReceiptId { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public int? ReceiptById { get; set; }
        public int? PurchaseOrderId { get; set; }
        public string Notes { get; set; }

        public string ReceiptDescription => $"{ReceiptId}: ({ReceiptDate:d} - {TotalReceipted:C0})";

        public Decimal TotalReceipted { get; set; }
        public Decimal TotalDaycost { get; set; }
    }

}
