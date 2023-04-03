using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class ApprovalWorkflowDto: IApprovalWorkflow
    {
        public int ApprovalWorkflowId { get; set; }
        public int? ApprovalCategoryId { get; set; }
        public int? ProjectId { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public int? WorkflowId { get; set; }

        public string ApprovalCategoryName { get; set; }

    }
}
