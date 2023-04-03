namespace cpModel.Dtos
{
    public partial class PhotoVariationDto
    {
        public int PhotoVrnId { get; set; }
        public int? PhotoId { get; set; }
        public int? PhotoNo { get; set; }
        public int? VrnId { get; set; }

        public string VrnNumber { get; set; }
        public string VrnDesc { get; set; }
        public string PhotoDescription { get; set; }
    }

}
