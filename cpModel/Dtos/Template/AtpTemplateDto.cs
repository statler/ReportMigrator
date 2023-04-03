using cpModel.Enums;
using cpModel.Helpers;
using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public partial class AtpTemplateDto : AtpDto
    {
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string DateSubmittedString => Datesub == null ? "" : Datesub.Value.ToShortDateString();
        public string DateResponseReqdString => DateRespRequired == null ? "" : DateRespRequired.Value.ToShortDateString();

        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Atp_Notification, AtpId);
        public string MobileSiteURL => APIConstants.MobileSiteURL;
        public string AtpLink => $@"<a href='{URL}'>ATP: {AtpNo}</a>";
        public string AtpLinkSiteURL => $@"<a href='{URL}'>{MobileSiteURL}</a>";
    }

}
