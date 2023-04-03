using cpModel.Enums;
using cpModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Template
{
    public class CnNotificationTemplateDto
    {
        public int ConId { get; set; }
        public string ConRef { get; set; }
        public DateTime? ConDate { get; set; }
        public DateTime? CloseOutDate { get; set; }
        public DateTime? DateResponseRequired { get; set; }
        public DateTime? DateSent { get; set; }
        public string ConDateAsString => ConDate?.ToShortDateString() ?? "";
        public string CloseOutDateAsString => CloseOutDate?.ToShortDateString() ?? "";
        public string DateResponseRequiredAsString => DateResponseRequired?.ToShortDateString() ?? "";
        public string DateSentAsString => DateSent?.ToShortDateString() ?? "";
        public string ConSubjectHtml { get; set; }
        public string ConSubjectPlainText => ConSubjectHtml.GetPlainTextFromHTML();

        public string RequestByName { get; set; }
        public string RequestOnBehalfName { get; set; }

        public ICollection<CnToDto> CnTos { get; set; } = new List<CnToDto>();

        public int NumberOfResponses { get; set; }
        public int NumberOfActionedResponses { get; set; }

        public string Status => CloseOutDate == null ? "Open" : "Closed";
        public string NoticeToCsv => string.Join(", ", CnTos.Select(x => x.FullName).ToList());
        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Contract_Notice_Notification, ConId);
        public string MobileSiteURL => APIConstants.MobileSiteURL;
        public string CnLink => $@"<a href='{URL}'>{ConRef})</a>";
        public string CnLinkSiteURL => $@"<a href='{URL}'>{MobileSiteURL}</a>";
    }
}
