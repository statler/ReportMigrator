namespace cpModel.Dtos
{
    public class LotPunchlistItemDto
    {
        public int LotPunchlistItemId { get; set; }
        public int? LotId { get; set; }
        public int? PunchlistItemId { get; set; }
        public int? PunchlistId { get; set; }

        public string LotNumber { get; set; }
        public string LotDescription { get; set; }

        public int? PunchlistNo { get; set; }
        public string PunchlistName { get; set; }
        public string PunchlistItemNo { get; set; }
        public string PunchlistNumDesc => $"{PunchlistItemNo}: {PunchlistNo} {PunchlistName} ";
    }
}
