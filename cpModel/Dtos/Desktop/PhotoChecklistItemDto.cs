namespace cpModel.Dtos
{
    public partial class PhotoChecklistItemDto
    {
        public int PhotoCheckId { get; set; }
        public int? PhotoId { get; set; }
        public int? PhotoNo { get; set; }
        public int? LotItpDetailId { get; set; }

        public int? LotItpId { get; set; }
        public string ChecklistLineDesc { get; set; }
        public string PhotoDescription { get; set; }
    }
}
