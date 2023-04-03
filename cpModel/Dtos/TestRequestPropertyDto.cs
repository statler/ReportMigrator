namespace cpModel.Dtos
{
    public class TestRequestPropertyDto
    {
        public int TestRequestPropertyId { get; set; }
        public int? TestRequestId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        public string PropertyNameValue => $"{PropertyName}: {PropertyValue}";
    }
}
