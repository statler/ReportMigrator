
using cpModel.Enums;
using cpModel.Helpers;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public partial class ApprovalTemplateDto : ApprovalListExtDto
    {
        public string ApprovalNoAndSubject => $"{ApprovalNo}: {SubjectPlainText}";
        public string BodyHtml { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string DateLastStepString => DateLastStep == null ? "" : DateLastStep.Value.ToShortDateString();
        public string DateLastStatusString => DateLastStep == null ? "" : DateLastStatus.Value.ToShortDateString();
        public string ActionDateString => ActionDate == null ? "" : ActionDate.Value.ToShortDateString();
        public string RequestDateString => RequestDate == null ? "" : RequestDate.Value.ToShortDateString();
        public string ProgressString => IsCompleted ? "Complete" : "In progress";
        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Approval, ApprovalId);

        public string ApprovalLink => $@"<a href='{URL}'>{ApprovalNo}</a>";
        public string ApprovalLinkSiteURL => $@"<a href='{URL}'>{APIConstants.MobileSiteURL}</a>";
        public string LastActionComment { get; set; }


        public string PriorityString => ((PriorityEnum)Priority).ToString();

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
        public List<WorkflowLogTemplateDto> WorkflowLogsOrdered { get; set; }
    }

}
