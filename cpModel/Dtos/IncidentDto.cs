using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class IncidentDto : IncidentBaseDto, IEditableObject
    {
        EditableModelHelper<IncidentDto> _editableImplementation = new EditableModelHelper<IncidentDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
    }
}
