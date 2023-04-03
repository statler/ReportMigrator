using System.IO;

namespace cpModel.Dtos
{
    public partial class FsVariationDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsVariationId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? VariationId { get; set; }
        public decimal? OrderId { get; set; }

        public string VariationNo { get; set; }
        public string VariationDesc { get; set; }
        public string FullVrnDesc => $"{VariationNo}: {VariationDesc}";

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => VariationId;
        public string RelatedName => FullVrnDesc;
    }
}
