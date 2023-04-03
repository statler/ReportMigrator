using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class NcrSetTemplateDto: TemplateSetBaseDto
    {
        //A wrapper for multiple lots
        public List<NcrTemplateDto> Ncrs { get; set; }
    }
}
