﻿using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace cpModel.Dtos.Desktop
{
    public class LotMapSectionEditDto : LotMapSectionDto, IEditableObject, ILockableEntity
    {
        //This frees up the inheritance chain as opposed to EditableModelBase<T>. I dont need it, but kept it for example
        EditableModelHelper<LotMapSectionEditDto> _editableImplementation = new EditableModelHelper<LotMapSectionEditDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();

    }
}
