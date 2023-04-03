using HtmlAgilityPack;
using cpModel.Helpers;

namespace cpModel.Dtos.Template
{
    public partial class WorkflowLogTemplateDto : WorkflowLogDto
    {
        public string LogDateString => LogDate == null ? "" : LogDate.Value.ToString("d");

        public string LogCommentHtmlNoDoc
        {
            get
            {
                if (string.IsNullOrEmpty(LogCommentHtml)) return null;
                var inlineHTML = LogCommentHtml.GetPlainTextFromHTML();
                HtmlDocument hd = new HtmlDocument();
                hd.LoadHtml(inlineHTML);
                var htmlNode = hd.DocumentNode.SelectNodes("//body");
                if (htmlNode != null && htmlNode.Count == 1)
                {
                    return htmlNode[0].InnerHtml;
                }
                return hd.DocumentNode.InnerText;
            }
        }


    }
}
