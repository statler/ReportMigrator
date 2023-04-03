

using cpModel.Dtos.Lookup;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class TestMethodReportDto : TestMethodLookupDto
    {
        public List<TestRequestTestReportDto> Tests;
        public List<TestResultFieldDto> ResultFields;
    }
}
