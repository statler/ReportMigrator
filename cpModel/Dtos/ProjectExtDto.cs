namespace cpModel.Dtos
{
    public class ProjectExtDto : ProjectDto
    {
        public string ClientContractNumber { get; set; }
        public string Location { get; set; }
        public string Principal { get; set; }
        public string PrincipalAbn { get; set; }
        public string ProjectAddress { get; set; }
        public string ClientCompany { get; set; }
        public string ContractorProjectNumber { get; set; }
        public string ContractorCompany { get; set; }
        public string ContractorAddress { get; set; }
        public string ContractNoAndDesc => ProjectNumberAndName;
    }
}
