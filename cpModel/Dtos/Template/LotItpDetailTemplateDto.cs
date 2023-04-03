using cpModel.Enums;
using cpModel.Helpers;

namespace cpModel.Dtos.Template
{
    public partial class LotItpDetailTemplateDto : LotItpDetailDto
    {
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string ItpDocNo { get; set; }
        public string ItpName { get; set; }
        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public string ReferenceText_Plain => ReferenceText.GetPlainTextFromHTML();

        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Approval_Check, LotItpDetailId);
        public string MobileSiteURL => APIConstants.MobileSiteURL;
        public string ChecklistLink => $@"<a href='{URL}'>{ReferenceText}</a>";
        public string ChecklistLinkSiteURL => $@"<a href='{URL}'>{MobileSiteURL}</a>";
    }

}
