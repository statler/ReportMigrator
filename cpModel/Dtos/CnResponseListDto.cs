using System;

namespace cpModel.Dtos
{
    public partial class CnResponseListDto
    {
        public int CnResponseId { get; set; }
        public int? CnId { get; set; }
        public int? ResponseById { get; set; }
        public string ResponseByName { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string ContractNoticeReference { get; set; }
        public string ContractNoticeSubjectHtml { get; set; }


    }

}
