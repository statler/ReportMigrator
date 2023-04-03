using System;

namespace cpModel.Dtos
{
    public class TestRequestForSummaryDto : TestRequestBasicDto
    {
        public int UploadCount { get; set; }
        public DateTime? LatestUploadDate { get; set; }

    }
}
