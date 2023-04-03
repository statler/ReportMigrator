using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class InvoiceListDto
    {
        public int InvoiceId { get; set; }
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string InvoiceRef { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceDesc { get; set; }
    }
}
