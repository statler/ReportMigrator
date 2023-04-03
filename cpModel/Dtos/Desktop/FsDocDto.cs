using System.IO;

namespace cpModel.Dtos
{
    public class FsDocDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsDocId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? DocId { get; set; }
        public int? RevId { get; set; }
        public decimal? OrderId { get; set; }

        public string DocumentNo { get; set; }
        public string DocumentDesc { get; set; }
        public string Revision { get; set; }
        public string DocumentNumRevDesc => $"{DocumentNo} (Rev {(string.IsNullOrWhiteSpace(Revision) ? "-" : Revision)}): {DocumentDesc}";
        public string DocumentNumDesc => $"{DocumentNo}: {DocumentDesc}";

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsRevDescription => $"(Rev {(string.IsNullOrWhiteSpace(Revision) ? "-" : Revision)}): {FsNo} ({FileDesc})";
        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => DocId;
        public string RelatedName => DocumentNumRevDesc;
    }
}
