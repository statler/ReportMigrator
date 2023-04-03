namespace cpModel.Dtos
{
    public partial class TagCodeDto
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string Description { get; set; }
        public bool? IsPrimary { get; set; }

        public string FirstLetter { get; set; }
    }

}
