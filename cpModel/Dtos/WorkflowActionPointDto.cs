namespace cpModel.Dtos
{
    public partial class WorkflowActionPointDto
    {
        public int WorkflowActionPointId { get; set; }
        public int? WorkflowActionId { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public int? Index { get; set; }

    }

}

