using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class SiteDiaryCostDto
    {
        public int SiteDiaryCostId { get; set; }
        public int? SiteDiaryId { get; set; }
        public DateTime? DiaryDate { get; set; }
        public int? SupplierId { get; set; }
        public string ResourceName { get; set; }
        public int? ResourceId { get; set; }
        public int? ResourceTypeId { get; set; }
        public decimal? Qty { get; set; }
        public string Unit { get; set; }
        public decimal? Rate { get; set; }
        public string Notes { get; set; }
        public string DocketRef { get; set; }
        public string SupplierName { get; set; }
        public decimal? Total { get; set; }
    }

}
