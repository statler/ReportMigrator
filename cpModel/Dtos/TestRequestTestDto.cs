using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class TestRequestTestDto : TestRequestTestBaseDto, IEditableObject, ILockableEntity
    {
        EditableModelHelper<TestRequestTestDto> _editableImplementation = new EditableModelHelper<TestRequestTestDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
    }

}
