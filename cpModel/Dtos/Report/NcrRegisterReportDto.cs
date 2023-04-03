using System.Collections.Generic;
using System.IO;

namespace cpModel.Dtos.Report
{
    public partial class NcrRegisterReportDto : NcrDto
    {
        public List<LotBasicReportDto> lstLots { get; set; }
        public string ShortDesc
        {
            get
            {
                if (Description == null) return null;
                using (var reader = new StringReader(Description))
                {
                    return reader.ReadLine();
                }
            }
        }

        public string RootCauseInclCategory
        {
            get
            {
                if (string.IsNullOrWhiteSpace(RootCauseCategory)) return RootCauseDetail;
                else if (string.IsNullOrWhiteSpace(RootCauseDetail)) return RootCauseCategory;
                else return $"{RootCauseCategory}: {RootCauseDetail}";
            }
        }
    }

}
