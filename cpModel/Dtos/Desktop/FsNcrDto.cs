using System.IO;

namespace cpModel.Dtos
{
    public partial class FsNcrDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsNcrId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? NcrId { get; set; }
        public decimal? OrderId { get; set; }


        public int? NcrNo { get; set; }
        public string NcrDesc { get; set; }
        public string FullNcrDesc => NcrNo == null ? "" : $"{NcrNo}: {NcrDesc}";

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => NcrId;
        public string RelatedName => FullNcrDesc;
    }
}
