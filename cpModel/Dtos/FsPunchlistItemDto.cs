using System.IO;

namespace cpModel.Dtos
{
    public partial class FsPunchlistItemDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsPunchlistItemId { get; set; }
        public int? PunchlistItemId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public decimal? OrderId { get; set; }
        public int? PunchlistId { get; set; }

        public int? PunchlistNo { get; set; }
        public string PunchlistName { get; set; }
        public string PunchlistItemNo { get; set; }
        public string PunchlistNumDesc => $"{PunchlistItemNo}: {PunchlistNo} {PunchlistName} ";
        public string Filename { get; set; }
        public string FileDesc { get; set; }
        public string FsDescription => $"{FsNo}: {FileDesc}";
        public string Extension => Path.GetExtension(Filename);
        public int? RelatedId => PunchlistItemId;
        public string RelatedName => PunchlistNumDesc;
    }
}
