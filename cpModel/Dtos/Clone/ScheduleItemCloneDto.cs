using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.CloneDto
{
    public partial class ScheduleItemCloneDto
    {
        public int ScheduleId { get; set; }
        public int? ProjectId { get; set; }
        public decimal? OrderId { get; set; }
        public int? ParentId { get; set; }
        public string ScheduleGroup { get; set; }
        public string ScheduleNumber { get; set; }
        public string Description { get; set; }
        public decimal? QtyForecast { get; set; }
        public decimal? QtyScheduled { get; set; }
        public string Unit { get; set; }
        public decimal? DjcRate { get; set; }
        public decimal? SellRate { get; set; }
        public bool? IsTotalled { get; set; }
        public string Notes { get; set; }
        public bool? IsVrn { get; set; }
        public bool? Disable { get; set; }
        public bool? IsOverhead { get; set; }
        public bool? IsVariableRate { get; set; }

    }

}
