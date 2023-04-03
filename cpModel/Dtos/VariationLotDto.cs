namespace cpModel.Dtos
{
    public partial class VariationLotDto
    {
        public int VariationLotId { get; set; }
        public int? VariationId { get; set; }
        public int? LotId { get; set; }


        public string FullLotDesc { get; set; }
        public string FullVariationDesc { get; set; }
    }
}
