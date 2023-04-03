using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using cpModel.Helpers;
using cpModel.Interfaces;

namespace cpModel.Dtos
{
    public partial class PunchlistItemDto : PunchlistItemBaseDto, IEditableObject, ILockableEntity, ITrackableEntity, IReplicableEntity, IOrderable
    {
        EditableModelHelper<PunchlistItemDto> _editableImplementation = new EditableModelHelper<PunchlistItemDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public string ApprovalComments { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }


    }
}
