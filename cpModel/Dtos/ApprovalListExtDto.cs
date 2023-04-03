using cpModel.Enums;
using cpModel.Helpers;
using cpModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class ApprovalListExtDto : ApprovalListDto, ILockableEntity
    { 
        EditableModelHelper<ApprovalListExtDto> _editableImplementation = new EditableModelHelper<ApprovalListExtDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
        public int? OptimisticLockField { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CloseOutByName { get; set; }
        public string DirectlyApprovedByName { get; set; }
        public int LogCount { get; set; }
        public int ActionCount { get; set; }
        public bool IsPublished { get; set; }


        public ApprovalStatusEnum ProgressStatus
        {
            get
            {
                if (IsCompleted)
                {
                    if (IsLatestStepAlert ?? false) return ApprovalStatusEnum.Completed_Alert;
                    else return ApprovalStatusEnum.Completed_Success;
                }
                if (IsApprovedToProceed) return ApprovalStatusEnum.Approved_To_Proceed;
                if (DateLastStep == null) return ApprovalStatusEnum.Not_started;
                return ApprovalStatusEnum.In_progress;
            }
        }

    }

}
// </auto-generated>
