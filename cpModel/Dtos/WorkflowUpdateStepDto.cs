using System;

namespace cpModel.Dtos
{
    public partial class WorkflowUpdateStepDto
    {
        public int WorkflowStepId { get; set; }
        public DateTime? DateLastCurrent { get; set; }
        public DateTime? DateLastActioned { get; set; }
        public int? OriginId { get; set; }
    }

}
