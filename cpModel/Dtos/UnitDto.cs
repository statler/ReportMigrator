using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public class UnitDto : UnitBaseDto, IEditableObject, ILockableEntity
    {
        //This frees up the inheritance chain as opposed to EditableModelBase<T>. I dont need it, but kept it for example
        EditableModelHelper<UnitDto> _editableImplementation = new EditableModelHelper<UnitDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();

    }
}
