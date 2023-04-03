using System;

namespace cpModel.Dtos
{
    public class ScheduleFlatListDto
    {
        public int ScheduleId { get; set; }
        public int? ProjectId { get; set; }
        public decimal? FlatOrder { get; set; }
        public string ScheduleNumber { get; set; }
        public decimal? QtyScheduled { get; set; }
        public string Unit { get; set; }
        public decimal? SellRate { get; set; }
        public bool? Disable { get; set; }
        public bool? IsOverhead { get; set; }
        public bool? IsVariableRate { get; set; }
        public decimal? LotQtyTotal { get; set; }
        public decimal LotQtyRemaining { get; set; }
        public bool IsHeading { get; set; }
        public int? Level { get; set; }
        public string Description { get; set; }
        public string IndentedItemName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(ScheduleNumber))
                    return $"{new string(' ', (Level ?? 0))}{Description}";
                else return $"{new string(' ', (Level ?? 0))}{ScheduleNumber}: {Description}";
            }
        }
        public decimal? DjcTotal { get; set; }
        public decimal? SellTotal { get; set; }
        public decimal ChildTotalDjc { get; set; }
        public decimal ChildTotalSell { get; set; }
    }
}
