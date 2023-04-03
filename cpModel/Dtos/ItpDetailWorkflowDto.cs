namespace cpModel.Dtos
{
    public partial class ItpDetailWorkflowDto
    {
        public int ItpDetailWorkflowId { get; set; }
        public int? ApprovalWorkflowId { get; set; }
        public int? ItpDetailId { get; set; }

        public string WorkflowName { get; set; }
    }

}
