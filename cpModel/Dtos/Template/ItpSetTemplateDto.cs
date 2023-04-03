using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class ItpSetTemplateDto : TemplateSetBaseDto
    {
        //A wrapper for multiple lots
        public List<ItpTemplateDto> Itps { get; set; }
    }
}
