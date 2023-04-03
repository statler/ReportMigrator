using cpModel.Enums;
using cpModel.Helpers;
using System;

namespace cpModel.Dtos.Template
{
    public class ItpTemplateDto
    {
        public int ItpId { get; set; }
        public string Description { get; set; }
        public string ItpDocnumber { get; set; }
        public int? RevisionId { get; set; }
        public string SpecRef { get; set; }
        public DateTime? RevisionDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string RevisionDateAsString => RevisionDate?.ToShortDateString() ?? "";
        public string ApprovalDateAsString => ApprovalDate?.ToShortDateString() ?? "";
        public string ItpNoDesc => $"{ItpDocnumber} - {Description}";
        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Itp_Notification, ItpId);

        public string ItpLink => $@"<a href='{URL}'>{ItpDocnumber}</a>";
        public string ItpLinkSiteURL => $@"<a href='{URL}'>{APIConstants.MobileSiteURL}</a>";
    }
}
