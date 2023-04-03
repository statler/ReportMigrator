using cpModel.Helpers;
using cpModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public class PurchaseOrderDto : PurchaseOrderBaseDto, IEditableObject, ILockableEntity
    {
        //This frees up the inheritance chain as opposed to EditableModelBase<T>. I dont need it, but kept it for example
        EditableModelHelper<PurchaseOrderDto> _editableImplementation = new EditableModelHelper<PurchaseOrderDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
        public int? OptimisticLockField { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string BillingEntity { get; set; }

        public int? SupplierId { get; set; }
        public int? ProjectId { get; set; }
        public int? PoContactId { get; set; }
        public int? ApprovedById { get; set; }
        public string ApprovalComments { get; set; }
        public DateTime? SupplierConfirmationDate { get; set; }
        public int? SupplierConfirmationById { get; set; }
        public string SupplierConfirmationNotes { get; set; }
        public decimal? PoBudget { get; set; }
        public bool IsApproved => ApprovedDate != null;


        public ApprovalListExtDto Approval { get; set; }
        public bool HasApproval => ApprovalId != null;
        public bool HasProblem => Approval?.IsLatestStepAlert ?? false;
        public decimal PoValueDisplay { get; set; }
        public decimal? TotalDaycost { get; set; }

    }
}
