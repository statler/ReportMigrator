namespace cpModel.Dtos.Lookup
{
    public class CnTemplateLookupDto
    {
        public int ConTempId { get; set; }
        public int? ProjectId { get; set; }
        public string Abbrev { get; set; }
        public string ConTempName { get; set; }
        public bool? RequiresResponse { get; set; }
        public bool? IsInactive { get; set; }
    }
}
