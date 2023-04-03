using cpModel.Helpers;
using System;

namespace cpModel.Dtos.Lookup
{
    public class ApprovalLookupDto
    {
        public int ApprovalId { get; set; }
        public int? ApprovalNo { get; set; }
        public string SubjectHtml { get; set; }
        public DateTime? RequestDate { get; set; }

        public string SubjectPlainText => SubjectHtml.GetPlainTextFromHTML();
    }
}
