namespace cpModel.Dtos
{
    public class ScheduleItemDto : ScheduleItemListDto
    {
        public int? ProjectId { get; set; }
        public int? ParentId { get; set; }
        public string ScheduleGroup { get; set; }
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
        public bool IsHeading { get; set; }
        public string SchedNumDesc
        {
            get => string.IsNullOrWhiteSpace(ScheduleNumber) ?
$"{Description} ({Unit})" : $"{ScheduleNumber}: {Description} ({Unit})";
        }
        public bool? IsUnboundFromVrn { get; set; } = false;
    }
}
