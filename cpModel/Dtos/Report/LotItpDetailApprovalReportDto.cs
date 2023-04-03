

namespace cpModel.Dtos.Report
{
    public partial class LotItpDetailApprovalReportDto
    {
        public int ApprovalLotItpDetailId { get; set; }
        public int? ApprovalId { get; set; }
        public int? LotItpDetailId { get; set; }

        public ApprovalListExtDto Approval { get; set; }

    }

}
