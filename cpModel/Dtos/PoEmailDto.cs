using System;

namespace cpModel.Dtos
{
    public partial class PoEmailDto
    {
        public int PoEmailId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public int? EmailLogId { get; set; }
        public int? EmailLogNo { get; set; }
        public string FullPoDesc { get; set; }
        public DateTime? EmailDate { get; set; }

        public string EmailDescription => $"{EmailLogId}: ({EmailDate:d})";
    }

}
// </auto-generated>

