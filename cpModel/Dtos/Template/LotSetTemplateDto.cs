using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class LotSetTemplateDto: TemplateSetBaseDto
    {
        //A wrapper for multiple lots
        public List<LotTemplateDto> Lots { get; set; }
    }
}
