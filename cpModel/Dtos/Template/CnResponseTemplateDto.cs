using HtmlAgilityPack;
using cpModel.Helpers;
using cpModel.Enums;

namespace cpModel.Dtos.Template
{
    public partial class CnResponseTemplateDto : CnResponseDto
    {
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }

        public string ResponseDateString => ResponseDate.HasValue ? ResponseDate.Value.ToShortDateString() : "";
        public string ActionRequiredDateString => ActionRequiredDate.HasValue ? ActionRequiredDate.Value.ToShortDateString() : "";

        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Contract_Notice_Response, CnId.Value);
        public string NoticeLink => $@"<a href='{URL}'>{ContractNoticeReference}</a>";
        public string NoticeLinkSiteURL => $@"<a href='{URL}'>{APIConstants.MobileSiteURL}</a>";

        public string ContractNoticeSubjectText => ContractNoticeSubjectHtml.GetPlainTextFromHTML();

        public string ResponseHtmlNoDoc
        {
            get
            {
                if (string.IsNullOrEmpty(ResponseHtml)) return null;
                HtmlDocument hd = new HtmlDocument();
                hd.LoadHtml(ResponseHtml);
                return hd.DocumentNode.InnerHtml;
            }
        }
    }
}
