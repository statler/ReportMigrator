using cpModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpModel.Dtos.Export
{
    public partial class ApprovalWorkflowExportDto
    {
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int ApprovalWorkflowId { get; set; }
        public int? ApprovalCategoryId { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public int? WorkflowId { get; set; }

        //Ignored in Automap - fill manually
        public WorkflowDto Workflow { get; set; }
    }

}
