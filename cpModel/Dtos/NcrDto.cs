using cpModel.Helpers;
using cpModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class NcrDto : NcrListDto, IEditableObject, ILockableEntity, INcr
    {
        EditableModelHelper<NcrDto> _editableImplementation = new EditableModelHelper<NcrDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
        public int? ProjectId { get; set; }
        //public string CorrectiveAction { get; set; }
        //public string PreventativeAction { get; set; }
        //public string RootCauseDetail { get; set; }
        //public string RootCauseCategory { get; set; }
        //public int? ActionType { get; set; }
        public string RelatedParties { get; set; }
        //public int? Severity { get; set; }
        //public int? ThirdPartyAppReqd { get; set; }
        public bool ThirdPartyAppReqd_bool { get => !((ThirdPartyAppReqd ?? 0) == 0); set => ThirdPartyAppReqd = value ? 1 : 0; }
        //public string Notes { get; set; }
        public int? ApprovalById { get; set; }
        //public string ApprovalDetails { get; set; }
        public int? CloseOutById { get; set; }
        public string CloseOutDetails { get; set; }
        public string RootCause { get; set; }
        public bool IsPublished { get => DatePublished != null; set => DatePublished = DateTime.UtcNow; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? OptimisticLockField { get; set; }


    }

}
