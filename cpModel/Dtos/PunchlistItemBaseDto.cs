using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using cpModel.Enums;
using cpModel.Helpers;
using cpModel.Interfaces;
using cpShared;

namespace cpModel.Dtos
{
    public partial class PunchlistItemBaseDto
    {
        public int PunchlistItemId { get; set; }
        public int? PunchlistId { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? PersonResponsibleId { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string Notes { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? CheckById { get; set; }
        public bool IsChecked { get => CheckDate != null; }
        public CheckStatusEnum CheckStatus
        {
            get
            {
                if (CheckDate != null) return CheckStatusEnum.Completed;
                else if (!(CheckReqd ?? true)) return CheckStatusEnum.Not_required;
                else return CheckStatusEnum.Not_completed;
            }
        }
        public DateTime? VerifyDate { get; set; }
        public int? VerifyById { get; set; }
        public bool IsVerified { get => VerifyDate != null; }
        public CheckStatusEnum VerifyStatus
        {
            get
            {
                if (VerifyDate != null) return CheckStatusEnum.Completed;
                else if (!(VerifyReqd ?? true)) return CheckStatusEnum.Not_required;
                else return CheckStatusEnum.Not_completed;
            }
        }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedById { get; set; }
        public bool IsApproved { get => ApprovedDate != null; }
        public CheckStatusEnum ApproveStatus
        {
            get
            {
                if (ApprovedDate != null) return CheckStatusEnum.Completed;
                else if (!(ApprovalReqd ?? true)) return CheckStatusEnum.Not_required;
                else return CheckStatusEnum.Not_completed;
            }
        }
        public bool IsCompleted { get; set; }
        public decimal? OrderId { get; set; }
        public int? ApprovalId { get; set; }
        public bool? CheckReqd { get; set; }
        public bool? VerifyReqd { get; set; }
        public bool? ApprovalReqd { get; set; }
        public bool? IsInternal { get; set; }
        public string ItemNo { get; set; }

    }
}
