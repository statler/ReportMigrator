
using cpModel.Helpers;
namespace cpModel.Dtos
{
    public partial class ApprovalNcrDto
    {
        public int ApprovalNcrId { get; set; }
        public int? ApprovalId { get; set; }
        public int? NcrId { get; set; }
        public int? ApprovalNo { get; set; }
        public string ApprovalSubjectHtml { get; set; }
        public string ApprovalSubjectPlainText => ApprovalSubjectHtml.GetPlainTextFromHTML();
        public int? NcrNumber { get; set; }
        public string NcrDescription { get; set; }
        public string FullNcrDesc => NcrNumber == null ? "" : $"{NcrNumber}: {NcrDescription}";
        public string ApprovalStatus { get; set; }
        public bool? ApprovalIsApprovedToProceed { get; set; }
        public bool? ApprovalIsCompleted { get; set; }
        public bool? ApprovalIsLatestStepAlert { get; set; }

    }

}
