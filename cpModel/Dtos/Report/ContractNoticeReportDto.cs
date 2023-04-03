using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.Report
{
    public class ContractNoticeReportDto : ContractNoticeListReportDto
    {
        public string ConHtml { get; set; }
        public string EffectiveFromName => string.IsNullOrEmpty(RequestOnBehalfName) ? RequestByName : RequestOnBehalfName;
        public ICollection<CnResponseDto> Responses { get; set; } = new List<CnResponseDto>();
    }
}
