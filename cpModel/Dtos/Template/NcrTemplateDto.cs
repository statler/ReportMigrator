using cpModel.Enums;
using cpModel.Helpers;
using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public partial class NcrTemplateDto : NcrDto
    {
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public virtual ICollection<LotShortListDto> Lots { get; set; }
        public string DateRaisedString => DateRaised == null ? "" : DateRaised.Value.ToShortDateString();

        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Approval_NCR, NcrId);
        public string MobileSiteURL => APIConstants.MobileSiteURL;
        public string NcrLink => $@"<a href='{URL}'>NCR: {NcrNo}</a>";
        public string NcrLinkSiteURL => $@"<a href='{URL}'>{MobileSiteURL}</a>";
    }

}
