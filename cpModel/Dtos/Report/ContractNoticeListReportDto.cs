using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpModel.Dtos.Report
{
    public class ContractNoticeListReportDto : ContractNoticeListDto
    {
        public string CnToCsv
        {
            get
            {
                if (CnTos == null || CnTos.Count == 0) return "";
                return string.Join(", ", CnTos.Select(x => x.FullName));
            }
        }
    }
}
