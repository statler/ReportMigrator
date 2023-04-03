using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class SiteDiarySetTemplateDto : TemplateSetBaseDto
    {
        public List<SiteDiaryTemplateDto> SiteDiaries { get; set; }
    }
}
