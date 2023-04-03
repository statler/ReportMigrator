using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class ApprovalsSetTemplateDto:TemplateSetBaseDto
    {
        //A wrapper for multiple lots
        public List<ApprovalForNotificationTemplateDto> Approvals { get; set; }
    }
}
