using System.IO;

namespace cpModel.Dtos
{
    public partial class FsAtpDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsAtpId { get; set; }
        public int? FsId { get; set; }
        public int? RegisterId { get; set; }
        public int? RegisterItemId { get; set; }
        public decimal? OrderId { get; set; }
        public int? FsNo { get; set; }

        public string AtpNo { get; set; }
        public string AtpDesc { get; set; }

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => RegisterItemId;
        public string RelatedName => $"{AtpNo} - {AtpDesc}";
    }
}
