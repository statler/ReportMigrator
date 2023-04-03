namespace cpModel.Dtos.Lookup
{
    public class TestMethodLookupDto
    {
        public int TestMethodId { get; set; }
        public string TestNum { get; set; }
        public string TestDescription { get; set; }

        public string TestNumDesc => $"{TestNum}: {TestDescription}";
    }
}
