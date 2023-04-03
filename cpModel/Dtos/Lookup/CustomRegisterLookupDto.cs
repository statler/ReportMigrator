namespace cpModel.Dtos.Lookup
{
    public partial class CustomRegisterLookupDto
    {
        public int CustomRegisterId { get; set; }
        public int? ProjectId { get; set; }
        public string CustomRegisterName { get; set; }
        public string ShortCode { get; set; }
    }
}
