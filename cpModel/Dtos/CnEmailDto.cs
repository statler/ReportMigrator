using System;

namespace cpModel.Dtos
{
    public class CnEmailDto
    {
        public int CnEmailId { get; set; }
        public int? EmailLogId { get; set; }
        public int? EmailLogNo { get; set; }
        public int? ContractNoticeId { get; set; }

        public string ConRef { get; set; }

        public DateTime EmailDate { get; set; }
        public string EmailSubject { get; set; }
        public string EmailFullDesc => $"{EmailLogNo}: {EmailSubject}";

    }

}
