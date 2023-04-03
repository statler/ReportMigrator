using cpModel.Helpers;
using cpModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public class TestRequestDto : TestRequestBaseDto, IEditableObject,  ILockableEntity
    {
        EditableModelHelper<TestRequestDto> _editableImplementation = new EditableModelHelper<TestRequestDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();

    }
}
