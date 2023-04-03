using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.Template
{
    public class SurveyRequestSetTemplateDto : TemplateSetBaseDto
    {
        public List<SurveyRequestTemplateDto> SurveyRequests { get; set; }
        public List<FsSurveyRequestTemplateDto> FilestoreDocsOrdered { get; set; }
    }
}
