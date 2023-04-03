using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class SupplierDivisionDto
    {
        public int SupplierDivisionId { get; set; }
        public int? SupplierId { get; set; }
        public int? DivisionId { get; set; }

        public string DivisionName { get; set; }

        public string SupplierName { get; set; }
    }

}
