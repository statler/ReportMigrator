using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class SurveyReportDto : SurveyRegisterReportDto
    {
        public List<SurveyChainageReportDto> lstChainages { get; set; }
        public string ToleranceCommentary { get; set; }
        public string MarkedCompletedByName { get; set; }
        public string Detail { get; set; }
    }
}
