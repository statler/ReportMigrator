
using System;
using System.Collections.Generic;

namespace cpModel.Dtos
{
    public partial class WorkflowDto
    {
        public int WorkflowId { get; set; }
        public int? ProjectId { get; set; }
        public string Description { get; set; }
        public int? OriginId { get; set; }
        public string StatusLastStep { get; set; }
        public DateTime? DateLastStep { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool? IsLatestStepAlert { get; set; }
        public bool? IsCompleted { get; set; }
        public string LastActionByName { get; set; }
        public int? LastActionById { get; set; }
        public string LastActionComment { get; set; }
        public int? LastStepId { get; set; }


        // Dont panic! these properties are ignored and must be manually filled.
        public virtual ICollection<WorkflowActionDto> WorkflowActions { get; set; }
        public virtual ICollection<WorkflowLogDto> WorkflowLogs { get; set; }
        public virtual ICollection<WorkflowStepDto> WorkflowSteps { get; set; }


    }

}

