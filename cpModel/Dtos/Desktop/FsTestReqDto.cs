using System;
using System.IO;

namespace cpModel.Dtos
{
    public partial class FsTestReqDto : IOrderableFsRelatedList, IFilestoreLink
    {
        public int FsTestReqId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? TestReqId { get; set; }
        public decimal? OrderId { get; set; }

        public int? TestReqNo { get; set; }
        public string TestReqDesc { get; set; }
        public string TestReqDescription => $"{TestReqNo}: {TestReqDesc}";

        public string Filename { get; set; }
        public string FileDesc { get; set; }
        public DateTime? FileDate { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public int? RelatedId => TestReqId;
        public string RelatedName => TestReqDescription;
    }
}
