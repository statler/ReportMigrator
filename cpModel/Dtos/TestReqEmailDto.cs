using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos
{
    public partial class TestReqEmailDto
    {
        public int TestReqEmailId { get; set; }
        public int? TestRequestId { get; set; }
        public int? EmailLogId { get; set; }
        public int? EmailLogNo { get; set; }
        public DateTime? EmailDate { get; set; }

        public int? TestReqNo { get; set; }
        public string TestReqLot { get; set; }
        public DateTime TestReqDate { get; set; }
        public string EmailDescription => $"{EmailLogNo}: ({EmailDate:d})";
    }
}
