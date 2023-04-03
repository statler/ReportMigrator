using cpModel.Dtos.Template;
using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace cpModel.Dtos
{
    public partial class TransmittalDto : TransmittalBaseDto, IEditableObject, ILockableEntity
    {
        EditableModelHelper<TransmittalDto> _editableImplementation = new EditableModelHelper<TransmittalDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();


        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

}
