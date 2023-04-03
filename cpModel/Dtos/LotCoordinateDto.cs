namespace cpModel.Dtos
{
    public partial class LotCoordinateDto
    {
        public int LotCoordinatesId { get; set; }
        public int? LotId { get; set; }
        public decimal? OrderId { get; set; }
        public decimal? Xcoord { get; set; }
        public decimal? Ycoord { get; set; }
        public decimal? Zcoord { get; set; }

    }

}
