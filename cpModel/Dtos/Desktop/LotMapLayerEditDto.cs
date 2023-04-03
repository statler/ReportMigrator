using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace cpModel.Dtos.Desktop
{
    public class LotMapLayerEditDto : LotMapLayerDto, IEditableObject, ILockableEntity
    {
        //This frees up the inheritance chain as opposed to EditableModelBase<T>. I dont need it, but kept it for example
        EditableModelHelper<LotMapLayerEditDto> _editableImplementation = new EditableModelHelper<LotMapLayerEditDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();

    }
}
