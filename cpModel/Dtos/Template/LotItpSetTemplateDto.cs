using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class LotItpSetTemplateDto: TemplateSetBaseDto
    {
        //A wrapper for multiple lots
        public List<LotItpTemplateDto> LotItps { get; set; }
    }
}
