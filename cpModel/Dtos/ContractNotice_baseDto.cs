using cpModel.Helpers;
using cpModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class ContractNotice_baseDto : ContractNoticeListDto, ILockableEntity
    {
        public int? ProjectId { get; set; }
        public int? ConTempId { get; set; }
        public int? ConTypeIx { get; set; }
        public int? RequestToId { get; set; }
        public bool? ResponseExpected { get; set; }
        public DateTime? DateLocked { get; set; }
        public int? ApprovalStatus { get; set; }
        public string CloseOutHtml { get; set; }
        public int? CloseOutById { get; set; }
        public int? ApproveToSendById { get; set; }
        public string Notes { get; set; }

        public bool IsClosedOut
        {
            get => CloseOutDate != null;
        }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? OptimisticLockField { get; set; }

        public string ResponseSummary => $"{NumberOfActionedResponses}/{NumberOfResponses}";
    }
}
