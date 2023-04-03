namespace cpModel.Dtos.Report
{
    public class ApprovalReportDto : ApprovalListReportDto
    {
        public string BodyHtml { get; set; }
        public string CloseOutCommentHtml { get; set; }
        public int? CloseOutNcrId { get; set; }
        public int? CloseOutApprId { get; set; }

    }
}
