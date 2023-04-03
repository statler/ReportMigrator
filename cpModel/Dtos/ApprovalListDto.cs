using cpModel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using cpModel.Dtos;
using cpModel.Helpers;

namespace cpModel.Dtos
{
    public class ApprovalListDto
    {
        public int ApprovalId { get; set; }
        public int? ApprovalNo { get; set; }
        public string SubjectHtml { get; set; }
        public int? RequestById { get; set; }
        public int? ResponseById { get; set; }
        public int? NcrLinkId { get; set; }
        public int? LotItpDetailLinkId { get; set; }
        public int? PurchaseOrderLinkId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? ApprovalCategoryId { get; set; }
        public int? ApprovalWorkflowBaseId { get; set; }
        public int? WorkflowId { get; set; }
        public DateTime? CloseOutDate { get; set; }
        public int? CloseOutById { get; set; }
        public DateTime? DateDirectlyApproved { get; set; }
        public int? DirectlyApprovedById { get; set; }

        public string WorkflowName { get; set; }
        public string ApprovalCategoryName { get; set; }
        public string RequestByName { get; set; }

        public bool IsCompleted { get; set; }
        public bool IsEmailed { get; set; }
        public DateTime? DateLastStep { get; set; }
        public bool? IsLatestStepAlert { get; set; }
        public int? DaysToComplete { get; set; }
        public DateTime? ActionDate { get; set; }

        public string LastActionByName { get; set; }
        public TimeSpan? temp { get; set; }
        public int? DaysTilDue { get; set; }
        public string StatusLastStep { get; set; }
        public string Status { get; set; }
        public DateTime? DateLastStatus { get; set; }
        public int? LastStepId { get; set; }
        public bool IsApprovedToProceed { get; set; }
        public int? Priority { get; set; }

        [JsonIgnore]
        public ICollection<ApprovalToDto> ApprovalTos { get; set; } = new List<ApprovalToDto>();
        [JsonIgnore]
        public ICollection<ApprovalCcDto> ApprovalCcs { get; set; } = new List<ApprovalCcDto>();

        //ApprovalTo derived
        public string ApprovalToCSV => string.Join(", ", ApprovalTos.Select(x => x.RequestTo == null ? x.RequestToEmail : x.RequestTo.FirstLast).ToList());
        public string ApprovalCcCSV => string.Join(", ", ApprovalCcs.Select(x => x.User == null ? x.CcEmail : x.User.FirstLast).ToList());

        public string SubjectPlainText => SubjectHtml.GetPlainTextFromHTML();

    }

}