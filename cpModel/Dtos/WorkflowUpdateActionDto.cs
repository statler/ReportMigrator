using System;

namespace cpModel.Dtos
{
    public partial class WorkflowUpdateActionDto
    {
        public int WorkflowActionId { get; set; }
        public int? OriginId { get; set; }
        public DateTime? DateLastActioned { get; set; }
    }

}
