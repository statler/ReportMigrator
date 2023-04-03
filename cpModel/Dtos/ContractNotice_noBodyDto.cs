using cpModel.Helpers;
using cpModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class ContractNotice_noBodyDto : ContractNotice_baseDto, IEditableObject, ILockableEntity
    {
        public virtual EditableModelHelper<ContractNotice_noBodyDto> _editableImplementation => new EditableModelHelper<ContractNotice_noBodyDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
    }
}
