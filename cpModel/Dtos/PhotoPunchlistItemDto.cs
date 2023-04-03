namespace cpModel.Dtos
{
    public partial class PhotoPunchlistItemDto
    {
        public int PhotoPunchListItemId { get; set; }
        public int? PhotoId { get; set; }
        public int? PhotoNo { get; set; }
        public int? PunchlistItemId { get; set; }
        public int? PunchlistId { get; set; }

        public int? PunchlistNo { get; set; }
        public string PunchlistName { get; set; }
        public string PunchlistItemNo { get; set; }
        public string PunchlistNumDesc => $"{PunchlistItemNo}: {PunchlistNo} {PunchlistName} ";

        public string PhotoDescription { get; set; }
    }
}
