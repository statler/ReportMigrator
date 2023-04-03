using cpModel.Helpers;
using cpModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public class GenerateTestSampleInfo
    {
        public TestRequestDto TestRequest { get; set; }
        public List<TestSummaryInfoDto> TestSummaries { get; set; }
        public int xRes { get; set; }
        public int yRes { get; set; }
        public int zRes { get; set; }
        public bool calcX { get; set; }
        public bool calcY { get; set; }
        public bool calcZ { get; set; }
    }
    public class TestSummaryInfoDto
    {
        //public int TestRequestId { get; set; }
        public int TestMethodId { get; set; }
        public int? ScheduleId { get; set; }
        public int NoTests { get; set; }
        public string ComplianceReq { get; set; }
        //public bool ManualOverride { get; set; }
        //public bool HasResults { get; set; }
        //public string Notes { get; set; }
    }
}
