using System;
using System.Collections.Generic;
using System.Text;
using cpModel.Interfaces;
using cpModel.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using cpModel.Enums;

namespace cpModel.Dtos
{
    public class SurveyRequestListDto 
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? SrNumber { get; set; }
        //public string SrNumberSuffix { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int SurveyId { get; set; }
        public int? RequestById { get; set; }
        public string Description { get; set; }
        public DateTime? DateReqd { get; set; }
        public DateTime? DateRequest { get; set; }
        public int? RequestToId { get; set; }
        public int? SurveyTypeId { get; set; }
        public SurveyTypeEnum? SurveyEnum
        { get => SurveyTypeId == null ? null : (SurveyTypeEnum?)SurveyTypeId; set => SurveyTypeId = (int?)value; }

        public string SurveyTypeName => SurveyEnum.ToString().Replace("_", " ");
        public string Notes { get; set; }
        public string RequestByName { get; set; }
        public string RequestToName { get; set; }
        public string CompleteByName { get; set; }
        public bool IsSurveyComplete { get; set; }

        public int? SurveyStatusId { get; set; }
        public DateTime? DateCompleted { get; set; }
        public int? MarkedCompletedBy { get; set; }
        public string CompletionComment { get; set; }
        public bool HasDoc { get; set; }
        public double? ToleranceAbove { get; set; }
        public double? ToleranceBelow { get; set; }
        public double? ToleranceThickness { get; set; }
        //public string ToleranceCommentary { get; set; }

    }
}
