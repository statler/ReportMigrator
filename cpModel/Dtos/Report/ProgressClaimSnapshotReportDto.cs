namespace cpModel.Dtos.Report
{
    public partial class ProgressClaimSnapshotReportDto
    {
        public int ProgressClaimSnapshotId { get; set; }
        public int ParentLevel { get; set; }
        public int? ProgressClaimVersionId { get; set; }
        public string Description { get; set; }
        public decimal? Qty { get; set; }
        public decimal EffQty { get; set; }
        public string Unit { get; set; }
        public int? Status { get; set; }
        public string StatusText { get; set; }

        public string DescriptionWithIndent => $"{new string(' ', (ParentLevel + 1))}{Description}";
        public string StatusTextWithIndent => $"{new string(' ', (ParentLevel + 1))}{StatusText}";
    }
}
