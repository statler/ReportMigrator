namespace cpModel.Dtos
{
    public class ScheduleFlatDto : ScheduleFlatListDto
    {
        public decimal? OrderId { get; set; }
        public int? ParentId { get; set; }
        public decimal? QtyForecast { get; set; }
        public decimal? DjcRate { get; set; }
        public bool? IsTotalled { get; set; }
        public string Notes { get; set; }
        public bool? IsVrn { get; set; }
        public bool IsSummaryLine { get; set; } = false;


    }
}
