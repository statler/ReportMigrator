using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using cpModel.Helpers;
using cpModel.Interfaces;

namespace cpModel.Dtos
{
    public partial class PunchlistDto : IEditableObject, ILockableEntity, ITrackableEntity, IReplicableEntity
    {
        EditableModelHelper<PunchlistDto> _editableImplementation = new EditableModelHelper<PunchlistDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }


        public int PunchlistId { get; set; }
        public int? PunchlistNo { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? DateRaised { get; set; }
        public string Description { get; set; }
        public int? RaisedById { get; set; }
        public int? ApprovedById { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool? IsSoftDeleted { get; set; }


        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }
    }
}
