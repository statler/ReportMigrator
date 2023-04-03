
using cpModel.Helpers;
namespace cpModel.Dtos
{
    public partial class ApprovalItpDetailDto
    {
        public int ApprovalItpDetailId { get; set; }
        public int? ApprovalId { get; set; }
        public int? ItpDetailId { get; set; }
        public int? ApprovalNo { get; set; }
        public string ApprovalSubjectHtml { get; set; }
        public string ApprovalSubjectPlainText => ApprovalSubjectHtml.GetPlainTextFromHTML();
        public string ItpDetailDesc { get; set; }
        public int? ItpId { get; set; }
        public string FullItpDesc { get; set; }
    }

}
