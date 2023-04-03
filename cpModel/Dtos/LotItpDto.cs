
using cpModel.Enums;
using cpModel.Helpers;
using cpModel.Interfaces;
using cpModel.Models;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class LotItpDto : IEditableObject, ILotItp, ILockableEntity
    {
        //This frees up the inheritance chain as opposed to EditableModelBase<T>. I dont need it, but kept it for example
        EditableModelHelper<LotItpDto> _editableImplementation = new EditableModelHelper<LotItpDto>();

        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();

        public int LotItpId { get; set; }
        public int? LotId { get; set; }
        public int? ItpId { get; set; }
        public int? RaisedById { get; set; }
        public string Description { get; set; }
        public decimal? LotQuantity { get; set; }
        public string Unit { get; set; }
        public int? ApprovedById { get; set; }
        public DateTime? DateApproved { get; set; }
        public string ApprovalComments { get; set; }
        public int? CheckedById { get; set; }
        public DateTime? DateChecked { get; set; }
        public int? VerifiedById { get; set; }
        public DateTime? DateVerified { get; set; }
        public decimal? LotLength { get; set; }
        public decimal? LotArea { get; set; }
        public decimal? LotVolume { get; set; }
        public DateTime? RevisionDate { get; set; }
        public int? RevisionId { get; set; }
        public DateTime? ChecklistDate { get; set; }
        public string SourceItpNo { get; set; }
        public string SourceQvcNo { get; set; }
        public int? Priority { get; set; }
        public int PriorityEff { get => Priority ?? (int) PriorityEnum.Normal; set=> Priority=value; }

        public string LotNumber { get; set; }
        public string ItpDescription { get => ItpName; set => ItpName = value; }
        public string RaisedByName { get; set; }
        public string ApprovedByName { get; set; }
        public string WorkTypeName { get; set; }
        public string AreaCodeName { get; set; }
        public bool AllChecked { get; set; }
        public bool AllVerified { get; set; }
        public bool AllApproved { get; set; }

        public string DescInclLot => string.IsNullOrWhiteSpace(LotNumber) ? Description : $"{LotNumber}: {Description}";

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? OptimisticLockField { get; set; }
        public DateTime? DateRejected { get; set; }
        public DateTime? DateConformed { get; set; }
        public DateTime? DateGuaranteed { get; set; }
        public DateTime? EffectiveCloseDate => DateApproved ?? DateConformed ?? DateGuaranteed;

        public virtual string Status { get; set; }

        public string ItpName { get; set; }

        public bool IsClosedOut => DateApproved != null;

    }
}
