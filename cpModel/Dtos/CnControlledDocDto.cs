
using cpModel.Helpers;
using cpModel.Interfaces;

namespace cpModel.Dtos
{
    public class CnControlledDocDto : IAttachable, INoticeLink, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int CnContDocId { get; set; }
        public int? CnId { get; set; }
        public int? ContDocId { get; set; }
        public bool? InclNotice { get; set; }


        public bool? InclAtt { get; set; }
        public string DocumentNo { get; set; }
        public string DocumentDesc { get; set; }
        public string DocumentNoDesc => $"{DocumentNo}: {DocumentDesc}";
        public string CnNumber { get; set; }
        public string CnSubjectHtml { get; set; }
        public string CnDescPlainText => CnSubjectHtml.GetPlainTextFromHTML();
    }
}
