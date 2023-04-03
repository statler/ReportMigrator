using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class ItpDto : ItpListDto, IEditableObject, ILockableEntity
    {
        EditableModelHelper<ItpDto> _editableImplementation = new EditableModelHelper<ItpDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();

        public int? OptimisticLockField { get; set; }
        public int? ProjectId { get; set; }
        public int? PersonControlId { get; set; }
        public int? ApprovedById { get; set; }
        public string ApprovalComment { get; set; }
        public string DocNumDesc => $"{ItpDocnumber ?? ""}: {Description ?? ""}";
        public bool IsApproved => ApprovalDate != null;
    }

}
