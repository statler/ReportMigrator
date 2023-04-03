namespace cpModel.Interfaces
{
    public interface IApprovalWorkflow
    {
        int ApprovalWorkflowId { get; set; }
        int? ApprovalCategoryId { get; set; }
        int? ProjectId { get; set; }
        string Description { get; set; }
        bool? IsActive { get; set; }
        bool? IsDefault { get; set; }
        int? WorkflowId { get; set; }

    }
}
