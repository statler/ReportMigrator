namespace cpModel.Dtos
{
    public partial class ApprovalCcDto
    {
        public int AprovalCcId { get; set; }
        public int? ApprovalId { get; set; }
        public int? UserId { get; set; }
        public string CcEmail { get; set; }

        public string FirstLast => User == null ? "" : User.FirstLast;
        public string Company => User == null ? "" : User.Company;
        public string Email => User == null ? CcEmail : User.Email;
        public string FirstLastCompany => string.IsNullOrEmpty(Company) ? FirstLast : $"{FirstLast} ({Company})";
        public virtual UserBasicDto User { get; set; }
    }
}
