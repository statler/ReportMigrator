namespace cpModel.Dtos.Lookup
{
    public class ProjectLookupDto
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public string ContractNumber { get; set; }
        public string ContractNoAndDesc => $"{ContractNumber}: {Description}";

    }
}
