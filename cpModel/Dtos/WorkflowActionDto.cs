using System;
using System.Collections.Generic;

namespace cpModel.Dtos
{
    public partial class WorkflowActionDto
    {
        public int WorkflowActionId { get; set; }
        public int? WorkflowId { get; set; }
        public int? StepFromId { get; set; }
        public int? StepToId { get; set; }
        public int? BeginConnIx { get; set; }
        public int? EndConnIx { get; set; }
        public string Text { get; set; }
        public decimal? TextPosition { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsNotify { get; set; }
        public bool? IsPrivate { get; set; }
        public int? ActionGroupIndex { get; set; }
        public bool? AddresseeCanAction { get; set; }
        public bool? RequestorCanAction { get; set; }
        public int? OriginId { get; set; }
        public bool? IsReqCommentary { get; set; }
        public int? PriorityOrderId { get; set; }
        public DateTime? DateLastActioned { get; set; }
        public int? ReferencePriority { get; set; }
        public decimal? MinValueForAction { get; set; }


        // Dont panic! these properties are ignored and must be manually filled.
        public virtual ICollection<WorkflowActionPointDto> WorkflowActionPoints { get; set; }
        public virtual ICollection<WorkflowActionRoleDto> WorkflowActionRoles { get; set; }
        public virtual ICollection<WorkflowActionUserDto> WorkflowActionUsers { get; set; }
    }

}
