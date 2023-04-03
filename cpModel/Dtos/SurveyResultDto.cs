using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class SurveyResultDto : SurveyResultBaseDto, IEditableObject, ILockableEntity
    {
        EditableModelHelper<SurveyResultDto> _editableImplementation = new EditableModelHelper<SurveyResultDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
    }
}
