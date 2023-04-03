
using cpModel.Helpers;
using System;

namespace cpModel.Dtos
{
    public partial class ApprovalEmailDto
    {
        public int ApprovalEmailId { get; set; }
        public int? ApprovalId { get; set; }
        public int? EmailLogId { get; set; }
        public int? EmailLogNo { get; set; }
        public bool? IsPrivate { get; set; }

        public DateTime EmailDate { get; set; }
        public string EmailDescription { get; set; }
        public string EmailShortDescription => $"{EmailLogNo}: ({EmailDate:d})";
        public int? ApprovalNo { get; set; }
        public string ApprovalSubjectHtml { get; set; }
        string ApprovalSubjectAsText => ApprovalSubjectHtml.GetPlainTextFromHTML();
        public string ApprovalNumDescription => $"{ApprovalNo.ToString()}: {ApprovalSubjectAsText}";
    }
}
