using System;

namespace cpModel.Dtos.Report
{
    public class ChecklistReportDto
    {

        public int LotItpId { get; set; }
        public int? LotId { get; set; }
        public int? ItpId { get; set; }
        public string ITPName { get; set; }
        public string Description { get; set; }
        public string ApprovalComments { get; set; }
        public DateTime? RevisionDate { get; set; }
        public int? RevisionId { get; set; }
        public DateTime? ChecklistDate { get; set; }
        public string SourceItpNo { get; set; }
        public string SourceQvcNo { get; set; }

        public string RaisedByName { get; set; }
        public string ApprovedByName { get; set; }
    }
}
