namespace cpModel.Dtos.Lookup
{
    public class WorkflowStepLookupDto
    {
        public int WorkflowStepId { get; set; }
        public string Description => Text.Replace("\r\n", "").Replace("\n", "");
        public string Text { get; set; }
        public bool? IsLastStep { get; set; }
        public bool? IsFirstStep { get; set; }
    }
}
