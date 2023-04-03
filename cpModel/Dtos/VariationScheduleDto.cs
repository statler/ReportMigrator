namespace cpModel.Dtos
{
    public partial class VariationScheduleDto
    {

        public int VariationScheduleId { get; set; }
        public int? VariationId { get; set; }
        public int? ScheduleId { get; set; }
        public string VariationDesc { get; set; }
        public string ScheduleDesc { get; set; }
        public decimal? FlatOrder { get; set; }
    }
}
