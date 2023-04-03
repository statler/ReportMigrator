using cpModel.Models;
using System;

namespace cpModel.Dtos.Report
{
    public class CCSummary
    {
        public string CCName { get; set; }
        public string SupplierName { get; set; }
        public string ResourceName { get; set; }
        public string Unit { get; set; }
        public decimal Rate { get; set; }
        public decimal Qty { get; set; }
        public decimal Total => Math.Round(Qty * Rate, 2, MidpointRounding.AwayFromZero);

        public CCSummary(string costCodeName, string supplierName, string resourceName, string unit, decimal qty, decimal rate)
        {
            CCName = costCodeName;
            SupplierName = supplierName;
            ResourceName = resourceName;
            Unit = unit;
            Qty = qty;
            Rate = rate;
        }

    }
}
