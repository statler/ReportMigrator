using System;

namespace cpModel.Dtos
{
    public class EmailLogListDto
    {
        public int EmailLogId { get; set; }
        public int EmailLogNo { get; set; }
        public int? ProjectId { get; set; }
        public string EmailTo { get; set; }
        public string EmailCc { get; set; }
        public string Subject { get; set; }
        public DateTime? DateEmailed { get; set; }
    }

}
