

using cpModel.Dtos.Lookup;

namespace cpModel.Dtos.Report
{
    public partial class NcrLotReportDto
    {
        public int NcrLotId { get; set; }
        public int? NcrId { get; set; }
        public int? LotId { get; set; }


        public LotBasicReportDto Lot { get; set; }
        public NcrLookupDto Ncr { get; set; }

    }

}
