using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class ApprovalWorkflowUpdaterDto : ApprovalWorkflowDto, IEditableObject,  ILockableEntity
    {
        EditableModelHelper<ApprovalWorkflowUpdaterDto> _editableImplementation = new EditableModelHelper<ApprovalWorkflowUpdaterDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
        public int? OptimisticLockField { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

}
