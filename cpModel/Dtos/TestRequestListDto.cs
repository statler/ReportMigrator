using System;

namespace cpModel.Dtos
{
    public class TestRequestListDto : TestRequestBasicDto
    {
        public int? RequestedById { get; set; }
        public int? LotId { get; set; }
        public int? TestRequestToId { get; set; }
        public DateTime? DateTestCompleted { get; set; }
        public virtual bool TestComplete { get; set; }
        public int? GeometryType { get; set; }
        public decimal? ChStart { get; set; }
        public decimal? ChEnd { get; set; }
        public string ControlLineName { get; set; }

        public int UploadCount { get; set; }
        public bool HasDoc { get; set; }
        public bool HasTest { get; set; }
        public DateTime? LatestUploadDate { get; set; }
        public DateTime? LatestEmailDate { get; set; }

    }
}
