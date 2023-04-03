using System;

namespace cpModel.Dtos
{
    public partial class WorkflowStepDto
    {
        public int WorkflowStepId { get; set; }
        public int? WorkflowId { get; set; }
        public string Text { get; set; }
        public bool? IsFirstStep { get; set; }
        public bool? IsLastStep { get; set; }
        public int? DaysToComplete { get; set; }
        public DateTime? DateLastCurrent { get; set; }
        public DateTime? DateLastActioned { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsAlertStep { get; set; }
        public bool? IsWarningStep { get; set; }
        public bool? IsApprovalStep { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public int? OriginId { get; set; }
        public int? Zindex { get; set; }
    }

}
