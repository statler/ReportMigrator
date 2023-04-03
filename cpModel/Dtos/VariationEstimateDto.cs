namespace cpModel.Dtos
{
    public partial class VariationEstimateDto
    {
        public int VariationEstimateId { get; set; }
        public int? VariationId { get; set; }
        public decimal? ItemOrder { get; set; }
        public string Description { get; set; }
        public decimal? Qty { get; set; }
        public string Unit { get; set; }
        public decimal? DjcTotal { get; set; }
        public decimal? SellTotal { get; set; }
        public decimal? VisibleMargin { get; set; }
        public string Comment { get; set; }

    }
}
