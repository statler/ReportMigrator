using System;
using System.IO;

namespace cpModel.Dtos.Template
{
    public class FsSurveyRequestTemplateDto : FsSurveyDto, IFilestoreDocsBase
    {
        public string FileDateAsString => FileDate == null ? "" : FileDate.Value.ToShortDateString();
        public int? SurveyRequestNo { get; set; }
        public string SurveyRequestDesc { get; set; }
        public string SurveyRequestDescription => $"{SurveyRequestNo}: {SurveyRequestDesc}";
    }
}
