using cpModel.Helpers;
using cpModel.Interfaces;
using System.IO;

namespace cpModel.Dtos
{
    public partial class FsNoticeDto : IOrderableFsRelatedList, IFilestoreLink, IAttachable, INoticeLink, ILockableEntity
    {
        public int? OptimisticLockField { get; set; }
        public int FsNoticeId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? CnId { get; set; }
        public bool? InclNotice { get; set; }


        public bool? InclAtt { get; set; }
        public bool? InResponse { get; set; }
        public int? ResponseId { get; set; }
        public decimal? OrderId { get; set; }

        public string CnRef { get; set; }
        public string CnSubjectHtml { get; set; }
        public string CnSubjectPlainText => CnSubjectHtml.GetPlainTextFromHTML();
        public string CnFullDesc => $"{CnRef}: {CnSubjectPlainText}";

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => CnId;
        public string RelatedName => CnRef;
    }
}
