using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class CnSetTemplateDto :TemplateSetBaseDto
    {
        //A wrapper for multiple lots
        public List<CnNotificationTemplateDto> ContractNotices { get; set; }
    }
}
