using System;

namespace cpModel.Dtos
{
    public partial class WorkflowActionWithToStepDto
    {
        public int WorkflowActionId { get; set; }
        public int? StepFromId { get; set; }
        public int? StepToId { get; set; }
        public string Text { get; set; }
        public bool? IsReqCommentary { get; set; }
        public int? PriorityOrderId { get; set; }
        public int? ActionGroupIndex { get; set; }
        public bool? AddresseeCanAction { get; set; }
        public bool? RequestorCanAction { get; set; }
        public DateTime? DateLastActioned { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsNotify { get; set; }
        public bool? IsPrivate { get; set; }

        public WorkflowStepDto StepTo { get; set; }

    }

}
// </auto-generated>

