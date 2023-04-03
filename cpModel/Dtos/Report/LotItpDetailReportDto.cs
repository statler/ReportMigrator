
using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Report
{
    public partial class LotItpDetailReportDto : LotItpDetailDto, IItpDetailReportDto
    {
        public int RecordId => LotItpDetailId;
        public int? ParentId => LotItpId;
        public ApprovalListExtDto Approval { get; set; }
        public List<IItpTestReportDto> lstTest => lstLotItpTests.Cast<IItpTestReportDto>().ToList();

        //Manually populated
        public List<WorkflowLogDto> lstWorkflowLog { get; set; }
        //Manually populated
        public List<LotItpTestReportDto> lstLotItpTests { get; set; }

        //Used in report for dummy subreport
        public List<ApprovalListExtDto> ApprovalInList
        {
            get
            {
                if (Approval == null) return null;
                return new List<ApprovalListExtDto>() { Approval };
            }
        }

        public List<LotItpDetailApprovalReportDto> lstLinkedApprovals { get; set; }

        public List<string> dummyManualApprovalSection { get; set; }

        public int? AtpNo { get; set; }
        public string AtpDesc { get; set; }
        public string LotNoDesc_ApprovalManual { get; set; }
        public string AtpNoDesc_ApprovalManual => AtpNo == null ? "" : $"{AtpNo}: {AtpDesc}";


        public string QvcTextEffective { get => Description; set => Description = value; }
        public bool? AuthorityRequired { get => ApprovalReqd; set => ApprovalReqd = value; }
        public bool? InspectRequired { get => CheckReqd; set => CheckReqd = value; }
        public bool? VerifyRequired { get => VerifyReqd; set => VerifyReqd = value; }
        public string InspMeth { get => InspMethod; set => InspMethod = value; }

        public decimal? ItemOrder { get => OrderId; set => OrderId = value; }
        public bool? QvcInc { get => true; set => throw new NotImplementedException(); }
    }

}
