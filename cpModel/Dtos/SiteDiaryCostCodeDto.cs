using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class SiteDiaryCostCodeDto
    {
        public int SiteDiaryCostCodeId { get; set; }
        public int? SiteDiaryCostId { get; set; }
        //public int? SiteDiaryId { get; set; }
        public int? CostCodeId { get; set; }
        public decimal? Qty { get; set; }

        public string CostCodeName { get; set; }
    }
}
