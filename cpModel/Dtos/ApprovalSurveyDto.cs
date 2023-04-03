using cpModel.Helpers;

namespace cpModel.Dtos
{
    public partial class ApprovalSurveyDto
    {
        public int ApprovalSurveyId { get; set; }
        public int? ApprovalId { get; set; }
        public int? SurveyId { get; set; }
        public int? ApprovalNo { get; set; }
        public string ApprovalSubjectHtml { get; set; }
        public string ApprovalSubjectPlainText => ApprovalSubjectHtml.GetPlainTextFromHTML();
        public int? SrNumber { get; set; }
        public string SurveyDescription { get; set; }
        public string FullSurveyDesc => SrNumber == null ? "" : $"{SrNumber}: {SurveyDescription}";
        public string ApprovalStatus { get; set; }
        public bool? ApprovalIsApprovedToProceed { get; set; }
        public bool? ApprovalIsCompleted { get; set; }
        public bool? ApprovalIsLatestStepAlert { get; set; }

    }
}
