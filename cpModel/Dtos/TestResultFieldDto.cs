namespace cpModel.Dtos
{

    public partial class TestResultFieldDto
    {
        public int TestResultFieldId { get; set; }
        public int? TestMethodId { get; set; }
        public decimal? OrderId { get; set; }
        public int? ResultFieldDataType { get; set; }
        public string ResultFieldName { get; set; }
        public string ResultUnit { get; set; }
    }

}
