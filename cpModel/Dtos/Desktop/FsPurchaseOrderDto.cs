using System.IO;

namespace cpModel.Dtos
{
    public partial class FsPurchaseOrderDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsPoId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? PurchaseOrderId { get; set; }
        public bool? InclAtt { get; set; }
        public decimal? OrderId { get; set; }

        public string FullPoDesc { get; set; }

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => PurchaseOrderId;
        public string RelatedName => FullPoDesc;
    }

}
// </auto-generated>

