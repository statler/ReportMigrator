namespace cpModel.Dtos
{
    public partial class PhotoLotDto
    {
        public int PhotoLotId { get; set; }
        public int? PhotoId { get; set; }
        public int? PhotoNo { get; set; }
        public int? LotId { get; set; }

        public string LotNumber { get; set; }
        public string LotDesc { get; set; }
        public string PhotoDescription { get; set; }
    }
}
