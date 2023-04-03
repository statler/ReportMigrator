using System;
using System.Collections.Generic;
using cpModel.Enums;

namespace cpModel.Dtos.Report
{
    public class SurveyResultSetsReportDto
    {
        public int? SrNumber { get; set; }
        public int SurveyId { get; set; }
        public string Description { get; set; }
        public int? SurveyTypeId { get; set; }
        public string SurveyTypeDesc => Enum.GetName(typeof(SurveyTypeEnum), SurveyTypeId);
        public List<SurveyResultSetReportDto> lstResultSets { get; set; }
    }
}
