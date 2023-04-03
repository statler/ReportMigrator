namespace cpModel.Dtos
{
    public partial class PhotoNcrDto
    {
        public int PhotoNcrId { get; set; }
        public int? PhotoId { get; set; }
        public int? PhotoNo { get; set; }
        public int? NcrId { get; set; }

        public int? NcrNo { get; set; }
        public string NcrDesc { get; set; }
        public string PhotoDescription { get; set; }

    }
}
