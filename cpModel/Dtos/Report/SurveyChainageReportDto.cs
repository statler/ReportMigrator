using cpModel.Enums;
using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class SurveyChainageReportDto
    {
        public int SurveyChainageId { get; set; }
        public int? SurveyId { get; set; }
        public decimal? OrderId { get; set; }
        public int? ControlLineId { get; set; }
        public int? PositionTypeId { get; set; }
        public decimal? Chainage { get; set; }
        public decimal? LeftOs { get; set; }
        public decimal? RightOs { get; set; }
        public decimal? Rl { get; set; }
        public string ControlLineName { get; set; }
        public string PositionTypeString => PositionTypeId == null ? "" : Enum.GetName(typeof(PositionTypeEnum), PositionTypeId); 
        public string ChSummary => $"Ch:{Chainage:#,###,##0.###} O/S {LeftOs:#,###,##0.###} to {RightOs:#,###,##0.###} ({PositionTypeString})";

    }
}
