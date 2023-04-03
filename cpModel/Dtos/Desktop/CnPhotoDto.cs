
using cpModel.Helpers;
using cpModel.Interfaces;

namespace cpModel.Dtos
{
    public partial class CnPhotoDto : IAttachable, INoticeLink, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int CnPhotoId { get; set; }
        public int? CnId { get; set; }
        public int? PhotoId { get; set; }
        public int? PhotoNo { get; set; }
        public bool? InclNotice { get; set; }

        public bool? InclAtt { get; set; }

        public string CnNumber { get; set; }
        public string CnSubjectHtml { get; set; }
        public string PhotoDescription { get; set; }
        public string CnDescPlainText => CnSubjectHtml.GetPlainTextFromHTML();
    }

}
