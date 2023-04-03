namespace cpModel.Dtos.Lookup
{
    public class WorkflowActionLookupDto
    {
        public int WorkflowActionId { get; set; }
        public string Description => Text.Replace("\r\n", "").Replace("\n", "");
        public string Text { get; set; }
        public int? PriorityOrderId { get; set; }
    }
}
