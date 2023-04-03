
using cpModel.Helpers;
using cpModel.Interfaces;

namespace cpModel.Dtos
{
    public class CnApprovalDto : IAttachable, INoticeLink, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int CnApprovalId { get; set; }
        public int? CnId { get; set; }
        public int? ApprovalId { get; set; }
        public bool? InclNotice { get; set; }
        public bool? InclAtt { get; set; }


        public string ConRef { get; set; }
        public int? ApprovalNo { get; set; }

        public string ApprovalNumDescription => $"{ApprovalNo}: {ApprovalSubjectAsText}";
        public string ApprovalSubjectHtml { get; set; }
        string ApprovalSubjectAsText => ApprovalSubjectHtml.GetPlainTextFromHTML();

    }

}
