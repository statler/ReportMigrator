using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.Report
{
    public class PunchlistItemReportDto : PunchlistItemBaseDto
    {
        public string ApprovalComments { get; set; }

        public string PersonResponsibleName { get; set; }

        public string CheckedByInit { get; set; } = "";
        public string VerifiedByInit { get; set; } = "";
        public string ApprovedByInit { get; set; } = "";

        public string CheckedBySignoff => CheckDate == null ? "" : $"{CheckedByInit}{Environment.NewLine}{CheckDate:d/M/yy}";
        public string VerifiedBySignoff => VerifyDate == null ? "" : $"{VerifiedByInit}{Environment.NewLine}{VerifyDate:d/M/yy}";
        public string ApprovedBySignoff => ApprovedDate == null ? "" : $"{ApprovedByInit}{Environment.NewLine}{ApprovedDate:d/M/yy}";
    }
}
