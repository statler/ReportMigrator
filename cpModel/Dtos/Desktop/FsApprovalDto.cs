using cpModel.Helpers;
using cpModel.Interfaces;
using System.IO;

namespace cpModel.Dtos
{
    public partial class FsApprovalDto : IOrderableFsRelatedList, IFilestoreLink, ILockableEntity, IAttachable
    {
        public int? OptimisticLockField { get; set; }
        public int FsApprovalId { get; set; }
        public int? FsId { get; set; }
        public int? FilestoreDocNo { get; set; }
        public int? ApprovalId { get; set; }
        public bool? InclEmail { get; set; }
        public decimal? OrderId { get; set; }
        public int? RelatedId => ApprovalId;
        public string RelatedName => ApprovalNumDescription;

        public string ApprovalNumDescription => $"{ApprovalNo.ToString()}: {ApprovalSubjectAsText}";
        public int? ApprovalNo { get; set; }
        public string ApprovalSubjectHtml { get; set; }
        string ApprovalSubjectAsText => ApprovalSubjectHtml.GetPlainTextFromHTML();
        public string Extension => Path.GetExtension(Filename);

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FilestoreDocNo}: {FileDesc}";

        public bool? InclAtt { get => InclEmail; set => InclEmail = value; }

    }
}
