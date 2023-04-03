using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace cpModel.Dtos
{
    public class SurveyRequestExampleDto : ITrackableEntity, IReplicableEntity, ILockableEntity, IEditableObject
    {
        EditableModelHelper<SurveyRequestExampleDto> _editableImplementation = new EditableModelHelper<SurveyRequestExampleDto>();
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int SurveyId { get; set; }
        public int? SrNumber { get; set; }
        public string SrNumberSuffix { get; set; }
        public int? ProjectId { get; set; }
        public int? RequestById { get; set; }
        public DateTime? DateRequest { get; set; }
        public string Description { get; set; }
        public DateTime? DateReqd { get; set; }
        public int? RequestToId { get; set; }
        public int? SurveyTypeId { get; set; }
        public string Notes { get; set; }
        public DateTime? DateCompleted { get; set; }
        public int? MarkedCompletedBy { get; set; }
        public string CompletionComment { get; set; }
        public double? ToleranceAbove { get; set; }
        public double? ToleranceBelow { get; set; }
        public double? ToleranceThickness { get; set; }
        public string ToleranceCommentary { get; set; }

        public bool HasDoc { get; }


        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
    }
}
