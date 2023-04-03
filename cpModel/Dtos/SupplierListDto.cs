using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class SupplierListDto 
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string TradingName { get; set; }
        public string Description { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public bool? InActive { get; set; }
    }
}