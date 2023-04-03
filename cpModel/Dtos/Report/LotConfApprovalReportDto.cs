

using cpModel.Helpers;
using System;

namespace cpModel.Dtos.Report
{
    public class LotConfApprovalReportDto
    {
        public int LotId { get; set; }
        public int ApprovalId { get; set; }
        public int? ApprovalNo { get; set; }
        public string SubjectHtml { get; set; }
        public DateTime? RequestDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsApprovedToProceed { get; set; }
        public bool? IsLatestStepAlert { get; set; }
        public string LastActionByName { get; set; }
        public string Status { get; set; }
        public DateTime? DateLastStatus { get; set; }

        public string SubjectPlainText => SubjectHtml.GetPlainTextFromHTML();
    }
}
