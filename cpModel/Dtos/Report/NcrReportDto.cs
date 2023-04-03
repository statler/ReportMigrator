
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public partial class NcrReportDto : NcrRegisterReportDto
    {
        public List<PhotoNcrDto> lstPhotos { get; set; }
        public List<WorkflowLogDto> lstWorkflowLog { get; set; }

        public List<string> dummyMidSection { get; set; }
        public List<string> dummyEndSection { get; set; }

        public ApprovalListExtDto Approval { get; set; }
        public List<CustomRegisterValueReportDto> CustomRegisters { get; set; }


        //Used in report for dummy subreport
        public List<ApprovalListExtDto> ApprovalInList
        {
            get
            {
                if (Approval == null) return null;
                return new List<ApprovalListExtDto>() { Approval };
            }
        }
    }

}
