namespace cpModel.Dtos.Template
{
    public class LotBasicTemplateDto
    {
        public int LotId { get; set; }
        public string LotNumber { get; set; }
        public string Description { get; set; }
        public string LotInclDef => $"{LotNumber} : {Description}";
    }
}
