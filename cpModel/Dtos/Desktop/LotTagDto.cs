namespace cpModel.Dtos
{
    public class LotTagDto
    {
        public int LotTagId { get; set; }
        public int? LotId { get; set; }
        public int? TagId { get; set; }

        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
    }
}
