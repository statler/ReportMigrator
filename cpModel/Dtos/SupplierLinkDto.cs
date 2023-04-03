using System;
using System.Collections.Generic;
using System.Linq;
using cpModel.Models;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public partial class SupplierLinkDto
    {
        public int SupplierLinkId { get; set; }
        public int? SupplierId { get; set; }
        public int? ProjectId { get; set; }
        public SupplierDto Supplier { get; set; }
    }
}
