namespace cpModel.Dtos
{
    public partial class ApprovalToDto
    {
        public int ApprovalToId { get; set; }
        public int? ApprovalId { get; set; }
        public int? RequestToId { get; set; }
        public string RequestToEmail { get; set; }
        public string FirstLast => RequestTo == null ? "" : RequestTo.FirstLast;
        public string Company => RequestTo == null ? "" : RequestTo.Company;
        public string Email => RequestTo == null ? RequestToEmail : RequestTo.Email;
        public string FirstLastCompany => string.IsNullOrEmpty(Company) ? FirstLast : $"{FirstLast} ({Company})";
        public virtual UserBasicDto RequestTo { get; set; }

    }

}
