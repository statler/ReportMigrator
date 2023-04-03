using System.IO;

namespace cpModel.Dtos
{
    public partial class FsLotDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsLotId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? LotId { get; set; }
        public decimal? OrderId { get; set; }

        public string FullLotDesc { get; set; }

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => LotId;
        public string RelatedName => FullLotDesc;
    }
}
