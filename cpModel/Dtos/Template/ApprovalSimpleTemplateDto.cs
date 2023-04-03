using cpModel.Helpers;
using HtmlAgilityPack;
using System;

namespace cpModel.Dtos.Template
{
    public partial class ApprovalSimpleTemplateDto
    {
        public int ApprovalId { get; set; }
        public int? ApprovalNo { get; set; }
        public string SubjectHtml { get; set; }
        public string SubjectPlainText => SubjectHtml.GetPlainTextFromHTML();
        public string ApprovalNoAndSubject => $"{ApprovalNo}: {SubjectPlainText}";
        public string BodyHtml { get; set; }
        public string BodyHtmlNoDoc
        {
            get
            {
                if (string.IsNullOrEmpty(BodyHtml)) return null;
                HtmlDocument hd = new HtmlDocument();
                hd.LoadHtml(BodyHtml);
                return hd.DocumentNode.InnerHtml;
            }
        }
        public DateTime? RequestDate { get; set; }
        public DateTime? ActionDate { get; set; }
        public string ActionDateAsString => ActionDate?.ToShortDateString() ?? "";
        public string RequestDateAsString => RequestDate?.ToShortDateString() ?? "";
    }

}
