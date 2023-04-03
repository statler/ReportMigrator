using System;
using System.Collections.Generic;
using System.Text;
using cpModel.Interfaces;
using cpModel.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cpModel.Dtos
{
    public class SurveyRequestDto : SurveyRequestListDto, ITrackableEntity, IReplicableEntity, ILockableEntity, IEditableObject, ISurvey
    {
        EditableModelHelper<SurveyRequestDto> _editableImplementation = new EditableModelHelper<SurveyRequestDto>();
        public bool? IsSoftDeleted { get; set; }
        public int? ProjectId { get; set; }
        public bool HasFiles { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();

    }
}
