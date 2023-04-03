
using cpModel.Helpers;
namespace cpModel.Dtos
{
    public class ApprovalStatusInfoDto_Check
    {
        public int ApprovalId { get; set; }

        public int? ApprovalNo { get; set; }
        public string SubjectHtml { get; set; }
        public string ReferenceText { get; set; }
        public string SubjectPlainText => SubjectHtml.GetPlainTextFromHTML();
        public string ReferenceText_Plain => ReferenceText.GetPlainTextFromHTML();
        public string Status { get; set; }
        public bool IsApprovedToProceed { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsLatestStepAlert { get; set; }
    }
}
