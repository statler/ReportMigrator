namespace cpModel.Dtos
{
    public class TestResultDto
    {
        public int TestResultId { get; set; }
        public int? TestId { get; set; }
        public int? TestResultFieldId { get; set; }
        public string Result { get; set; }
    }
}
