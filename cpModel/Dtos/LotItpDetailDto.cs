using cpModel.Enums;
using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class LotItpDetailDto : IEditableObject, ILockableEntity, IOrderable
    {
        //This frees up the inheritance chain as opposed to EditableModelBase<T>. I dont need it, but kept it for example
        EditableModelHelper<LotItpDetailDto> _editableImplementation = new EditableModelHelper<LotItpDetailDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();

        public int? OptimisticLockField { get; set; }
        public int LotItpDetailId { get; set; }
        public decimal? OrderId { get; set; }
        public int? LotItpId { get; set; }
        public int? ItpDetailId { get; set; }
        public string ReferenceText { get; set; }
        public string Description { get; set; }
        public int? Hpwpc { get; set; }
        public int? ItemType { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? CheckedById { get; set; }
        public bool? CheckReqd { get; set; }
        public bool? CheckStatus { get; set; }
        public int? VerifyById { get; set; }
        public DateTime? VerifyDate { get; set; }
        public bool? VerifyReqd { get; set; }
        public bool? VerifyStatus { get; set; }
        public bool? ApprovalReqd { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int? ApprovedById { get; set; }
        public bool? ApproveStatus { get; set; }
        public int? ApprovalLotId { get; set; }
        public int? ApprovalAtpid { get; set; }
        public int? NcrId { get; set; }
        public string ApprovalReason { get; set; }
        public string Comment { get; set; }
        public string Clause { get; set; }
        public string Records { get; set; }
        public string Responsibility { get; set; }
        public string InspMethod { get; set; }
        public int? ApprovalId { get; set; }
        public DateTime? NotApplicableDate { get; set; }
        public int? NotApplicableById { get; set; }
        public string ItemNumberText { get; set; }

        public bool HasTests { get; set; }
        public int? NcrNo { get; set; }
        public bool HasStandingApproval { get; set; }

        public bool IsApprovalCompleted { get; set; }
        public bool IsApprovedToProceed { get; set; }
        public bool IsLatestStepAlert { get; set; }
        public string LatestApprovalStatus { get; set; }
        public bool? IsApprovedManually { get; set; }
        public bool? IsApprovedStanding { get; set; }

        //Provides information on the status for the entire row. Used for determining an appropriate style in the GUI
        //and when aggregated across the LotITP determining if it is completed.
        public virtual CheckStatusEnum RowStatus
        {
            get
            {
                if (NotApplicableDate != null) return CheckStatusEnum.Not_applicable;

                //Simple cases
                var IsCheckResolved = !(CheckReqd ?? false) || ((CheckReqd ?? false) && (CheckStatus ?? false));
                var IsVerifyResolved = !(VerifyReqd ?? false) || ((VerifyReqd ?? false) && (VerifyStatus ?? false));
                if (IsCheckResolved && IsVerifyResolved)
                {
                    if (!(ApprovalReqd ?? false) || ApproveDate != null) return CheckStatusEnum.Completed;
                }

                //Now with approval status
                if (ApprovalId == null) return CheckStatusEnum.Not_completed;
                if (IsLatestStepAlert) return CheckStatusEnum.Alert;
                //If completed but with alert, then will already have returned.
                if (IsApprovalCompleted) return CheckStatusEnum.Completed;
                return CheckStatusEnum.In_progress;
            }
        }

        //Info on the completion status of the check column
        public virtual CheckStatusEnum CheckStatusCalc
        {
            get
            {
                if (!(CheckReqd ?? false)) return CheckStatusEnum.Not_required;
                if (NotApplicableDate != null) return CheckStatusEnum.Not_applicable;
                if (CheckDate != null) return CheckStatusEnum.Completed;
                if (NcrId != null) return CheckStatusEnum.NCR;
                else return CheckStatusEnum.Not_completed;
            }
        }

        //Info on the completion status of the verify column
        public virtual CheckStatusEnum VerifyStatusCalc
        {
            get
            {
                if (!(VerifyReqd ?? false)) return CheckStatusEnum.Not_required;
                else if (NotApplicableDate != null) return CheckStatusEnum.Not_applicable;
                else if (VerifyDate != null) return CheckStatusEnum.Completed;
                else if (NcrId != null) return CheckStatusEnum.NCR;
                else return CheckStatusEnum.Not_completed;
            }
        }

        //Info on the completion status of the approval column
        public virtual CheckStatusEnum ApprovalStatusCalc
        {
            get
            {
                if (!(ApprovalReqd ?? false)) return CheckStatusEnum.Not_required;
                else if (NotApplicableDate != null) return CheckStatusEnum.Not_applicable;
                else if (ApproveDate != null) return CheckStatusEnum.Completed;
                else if (NcrId != null) return CheckStatusEnum.NCR;

                //Now with approval status
                else if (ApprovalId == null) return CheckStatusEnum.Not_completed;
                else if (IsLatestStepAlert) return CheckStatusEnum.Alert;
                //If completed but with alert, then will already have returned.
                else if (IsApprovalCompleted) return CheckStatusEnum.Completed;
                else if (IsApprovedToProceed) return CheckStatusEnum.Completed;
                return CheckStatusEnum.In_progress;
            }
        }

        public virtual CheckStatusEnum? NaStatusCalc
        {
            get
            {
                if (!(CheckReqd ?? false) && !(VerifyReqd ?? false) && !(ApprovalReqd ?? false)) return CheckStatusEnum.Not_required;
                if (NotApplicableDate != null) return CheckStatusEnum.Not_applicable;
                return null;
            }
        }

        public virtual bool IsActioned
        {
            get
            {
                return CheckStatusCalc == CheckStatusEnum.Completed || VerifyStatusCalc == CheckStatusEnum.Completed ||
                    (ApprovalStatusCalc != CheckStatusEnum.Not_completed && ApprovalStatusCalc != CheckStatusEnum.Not_required && ApprovalStatusCalc != CheckStatusEnum.Not_applicable);
            }
        }
        public virtual bool IsActionable
        {
            get
            {
                return (CheckReqd ?? false) || (VerifyReqd ?? false) || (ApprovalReqd ?? false);
            }
        }


        public HpWpCEnum? HpWpCTypeEnum
        {
            get => Hpwpc == null ? null : (HpWpCEnum?)Hpwpc; set => Hpwpc = (int?)value;
        }

        public ItpItemTypeEnum? ItemTypeEnum
        {
            get => ItemType == null ? null : (ItpItemTypeEnum?)ItemType; set => ItemType = (int)value;
        }

        public string ItemTypeString => ItemTypeEnum.ToString().Replace("_", " ");
        public string HpWpCString => HpWpCTypeEnum.ToString().Replace("_", " ");




    }

}
