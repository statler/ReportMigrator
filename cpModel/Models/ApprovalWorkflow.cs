// <auto-generated>
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace cpModel.Models
{
    public partial class ApprovalWorkflow: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int ApprovalWorkflowId { get; set; }
        public int? ApprovalCategoryId { get; set; }
        public int? ProjectId { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public int? WorkflowId { get; set; }
        public decimal? MinPoVal { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<Approval> Approvals { get; set; }
        public virtual ICollection<ApprovalWorkflowAddressee> ApprovalWorkflowAddressees { get; set; }
        public virtual ICollection<ItpDetailWorkflow> ItpDetailWorkflows { get; set; }

        public virtual ApprovalCategory ApprovalCategory { get; set; }
        public virtual Project Project { get; set; }
        public virtual Workflow Workflow { get; set; }

        public ApprovalWorkflow()
        {
            Approvals = new HashSet<Approval>();
            ApprovalWorkflowAddressees = new HashSet<ApprovalWorkflowAddressee>();
            ItpDetailWorkflows = new HashSet<ItpDetailWorkflow>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

