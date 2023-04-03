using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class ResourceDto
    {

        public int ResourceId { get; set; }
        public int? SupplierId { get; set; }
        public string ResourceName { get; set; }
        public decimal? Rate { get; set; }
        public string Unit { get; set; }
        public int? ResType { get; set; }
        public int? ProjectId { get; set; }
        public bool? IsHidden { get; set; }
        public bool? NotInvoiced { get; set; }
        public int? PurchaseOrderDetailId { get; set; }
        

    }
}
