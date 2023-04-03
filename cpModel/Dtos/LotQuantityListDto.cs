using System;
using System.Collections.Generic;
using System.Text;
using cpModel.Models;

namespace cpModel.Dtos
{
    public class LotQuantityListDto 
    {
        public int QuantityId { get; set; }
        public int? LotId { get; set; }

        public decimal? EffectivePercComp { get; set; }
        public string LotNumber { get; set; }

        public int? ScheduleId { get; set; }
        public string ScheduleName { get; set; }
        public decimal? Qty { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public string EffDescription { get; set; }

    }
}
