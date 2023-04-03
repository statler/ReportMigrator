using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Interfaces
{
    public interface ISurvey
    {
        int SurveyId { get; set; }
        int? SrNumber { get; set; }
       // string SrNumberSuffix { get; set; } //Ignore
        int? ProjectId { get; set; }
        int? RequestById { get; set; }
        DateTime? DateRequest { get; set; }
        string Description { get; set; }
        DateTime? DateReqd { get; set; }
        int? RequestToId { get; set; }
        int? SurveyTypeId { get; set; }
        string Notes { get; set; }
        DateTime? DateCompleted { get; set; }
        int? MarkedCompletedBy { get; set; }
        string CompletionComment { get; set; }
        double? ToleranceAbove { get; set; }
        double? ToleranceBelow { get; set; }
        double? ToleranceThickness { get; set; }
        //string ToleranceCommentary { get; set; }

    }
}
