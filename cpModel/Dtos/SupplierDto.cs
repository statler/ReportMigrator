using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public partial class SupplierDto : SupplierListDto
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public bool? NotInvoiced { get; set; }
        public string ExtReference { get; set; }
        public string SupplierAbn { get; set; }
        public int? SubscriberId { get; set; }

    }
}
