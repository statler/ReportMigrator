

using cpModel.Dtos.Lookup;
using System.Collections.Generic;
using cpModel.Enums;

namespace cpModel.Dtos.Report
{
    public class TestMethodReportDto_concrete : TestMethodReportDto
    {
        public float Fc { get; set; }
        public float Ft { get; set; }
        public ConcreteTestTypes Concrete_TestTypes { get; set; }
        public List<TestResultFieldDto> CylinderResultFields;
    }
}
