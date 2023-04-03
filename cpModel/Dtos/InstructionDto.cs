using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class InstructionDto : InstructionBaseDto, IEditableObject, ILockableEntity
    {
        EditableModelHelper<InstructionListDto> _editableImplementation = new EditableModelHelper<InstructionListDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
    }
}
