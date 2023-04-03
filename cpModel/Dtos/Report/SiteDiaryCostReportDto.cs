using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpModel.Dtos.Report
{
    public class SiteDiaryCostReportDto : SiteDiaryCostDto
    {
        public Lazy<List<CCSummary>> LstCcSummary => new Lazy<List<CCSummary>>(GetCCSummary);

        public List<SiteDiaryCostCodeDto> LstCostCode { get; set; } = new List<SiteDiaryCostCodeDto>();
        private List<CCSummary> GetCCSummary()
        {
            var ccSumaryItems = LstCostCode.Select(x => new CCSummary(x.CostCodeName, SupplierName, ResourceName, Unit, x.Qty ?? 0, Rate ?? 0)).ToList();
            var remainderQty = (Qty ?? 0) - ccSumaryItems.Sum(x => x.Qty);
            if (remainderQty != 0) ccSumaryItems.Add(new CCSummary("Unallocated", SupplierName, ResourceName, Unit, remainderQty, Rate ?? 0));
            return ccSumaryItems;
        }
    }
}
