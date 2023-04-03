
using cpModel.Helpers;
namespace cpModel.Dtos
{
    public class ApprovalLotDto
    {
        public int ApprovalLotId { get; set; }
        public int? ApprovalId { get; set; }
        public int? LotId { get; set; }

        public int? ApprovalNo { get; set; }
        public string ApprovalSubjectHtml { get; set; }
        public string ApprovalSubjectPlainText => ApprovalSubjectHtml.GetPlainTextFromHTML();
        public string LotNumber { get; set; }
        public string LotDescription { get; set; }
        public string FullLotDesc => $"{LotNumber}: {LotDescription}";
        public string ApprovalStatus { get; set; }
        public bool? ApprovalIsApprovedToProceed { get; set; }
        public bool? ApprovalIsCompleted { get; set; }
        public bool? ApprovalIsLatestStepAlert { get; set; }
    }
}
