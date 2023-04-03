namespace cpModel.Dtos
{
    public class DistributionDto
    {
        public int DistributionId { get; set; }
        public int? UserId { get; set; }
        public int? DocumentId { get; set; }
        public string DocumentNo { get; set; }
        public string DocumentDesc { get; set; }
        public string DocumentNoDesc => $"{DocumentNo}: {DocumentDesc}";
        public string UserFullName { get; set; }
    }
}
