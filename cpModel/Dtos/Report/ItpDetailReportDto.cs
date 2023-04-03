using cpModel.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Report
{
    public partial class ItpDetailReportDto : ItpDetailDto, IItpDetailReportDto
    {
        public int RecordId => ItpDetailId;
        public int? ParentId => ItpId;

        //Manually populated
        public List<ItpTestReportDto> lstItpTest { get; set; }
        public List<IItpTestReportDto> lstTest => lstItpTest.Cast<IItpTestReportDto>().ToList();

        public string HpwpcString
        {
            get
            {
                return Hpwpc != null && Hpwpc.Value > 0 ? ItpHelpers.ITPCheckTypeArray[(Hpwpc ?? 1) - 1] : "";
            }
        }

    }

}
