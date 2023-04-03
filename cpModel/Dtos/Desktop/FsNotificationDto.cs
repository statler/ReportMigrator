using System.IO;

namespace cpModel.Dtos
{
    public partial class FsNotificationDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsNotificationId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? NotificationId { get; set; }
        public decimal? OrderId { get; set; }

        public string FullNotificationDesc { get; set; }

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => NotificationId;
        public string RelatedName => FullNotificationDesc;
    }
}
