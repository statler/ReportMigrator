using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.CloneDto
{
    public class ItpCloneDto
    {
        public int ItpId { get; set; }
        public string Description { get; set; }
        public int? ProjectId { get; set; }
        public string Qvcdocnumber { get; set; }
        public string Itpdocnumber { get; set; }
        public int? PersonControlId { get; set; }
        public DateTime? RevisionDate { get; set; }
        public int? RevisionId { get; set; }
        public string SpecRef { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? ApprovedById { get; set; }
        public string ApprovalComment { get; set; }
    }
}
