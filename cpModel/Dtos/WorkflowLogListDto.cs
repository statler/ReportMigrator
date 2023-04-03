using System;

namespace cpModel.Dtos
{
    public partial class WorkflowLogListDto
    {
        public int WorkflowLogId { get; set; }
        public int? WorkflowId { get; set; }
        public int? UserId { get; set; }
        public DateTime? LogDate { get; set; }
        public bool? IsPrivate { get; set; }
        public int? WorkflowStepId { get; set; }
        public int? WorkflowActionId { get; set; }

        //Calculated
        public string LogByName { get; set; }
        public string ActionName { get; set; }
        public string StatusAfter { get; set; }
        public string StatusBefore { get; set; }

    }

}
