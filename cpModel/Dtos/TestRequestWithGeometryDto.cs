using System;

namespace cpModel.Dtos
{
    public class TestRequestWithGeometryDto : TestRequestListDto
    {
        public string TestRequestChainString => $"TR {TestRequestNo:D4}: {ControlLineName} Ch: {ChStart:#,##0.###} to {ChEnd:#,##0.###}";
        public string TestRequestDescString => $"TR {TestRequestNo:D4}: {Description}";
        public string TestRequestString => GeometryType == 2 ? TestRequestChainString : TestRequestDescString;
    }
}
