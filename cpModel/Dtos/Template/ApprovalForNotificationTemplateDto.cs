
using cpModel.Enums;
using cpModel.Helpers;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Template
{
    public partial class ApprovalForNotificationTemplateDto : ApprovalListDto
    {
        public string DateLastStepString => DateLastStep == null ? "" : DateLastStep.Value.ToShortDateString();
        public string DateLastStatusString => DateLastStep == null ? "" : DateLastStatus.Value.ToShortDateString();
        public string ActionDateString => ActionDate == null ? "" : ActionDate.Value.ToShortDateString();
        public string RequestDateString => RequestDate == null ? "" : RequestDate.Value.ToShortDateString();
        public string PublishDateString => RequestDate == null ? "" : PublishDate.Value.ToShortDateString();
        public string ProgressString => IsCompleted ? "Complete" : "In progress";
        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Approval, ApprovalId);

        public string ApprovalLink => $@"<a href='{URL}'>{ApprovalNo}</a>";
        public string ApprovalLinkSiteURL => $@"<a href='{URL}'>{APIConstants.MobileSiteURL}</a>";
        public string PriorityString => Priority == null ? string.Empty : ((PriorityEnum)Priority).ToString();


    }

}
