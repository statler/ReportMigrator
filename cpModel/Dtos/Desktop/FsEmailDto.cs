using System.IO;

namespace cpModel.Dtos
{
    public partial class FsEmailDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsEmailId { get; set; }
        public int? EmailLogId { get; set; }
        public int? EmailLogNo { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public decimal? OrderId { get; set; }

        public string EmailSubject { get; set; }
        public string EmailFullDesc => $"{EmailLogNo}: {EmailSubject}";

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => EmailLogId;
        public string RelatedName => EmailFullDesc;
    }
}
