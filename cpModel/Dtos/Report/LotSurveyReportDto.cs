using cpModel.Dtos.Lookup;

namespace cpModel.Dtos.Report
{
    public partial class LotSurveyReportDto
    {
        public int SurveyLotId { get; set; }
        public int? SurveyId { get; set; }
        public int? LotId { get; set; }
        public LotBasicReportDto Lot { get; set; }
        public SurveyRequestLookupDto Survey { get; set; }
    }
}
