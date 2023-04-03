
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public class ApprovalListReportDto : ApprovalListExtDto
    {
        public List<WorkflowLogDto> lstWorkflowLog { get; set; }
        public string DaysTilDueBracketed => $"({DaysTilDue.ToString()})";
        public string DateAndDaysTilDue => $"({ActionDate:d} {DaysTilDueBracketed})";
    }
}
