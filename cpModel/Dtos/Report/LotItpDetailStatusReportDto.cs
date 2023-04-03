using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public partial class LotItpDetailStatusReportDto : LotItpDetailDto
    {
        public string ApprovalStatusCalcString => ApprovalStatusCalc.ToString();
        public List<ApprovalLotItpDetailReportDto> AllApprovals { get; set; }
        
    }

}
