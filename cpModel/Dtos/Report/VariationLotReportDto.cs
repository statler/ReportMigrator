
namespace cpModel.Dtos.Report
{
    public partial class VariationLotReportDto : VariationLotDto
    {
        public string LotNumber { get; set; }
        public string LotDesc { get; set; }
        public string VarNo { get; set; }
        public string VarDesc { get; set; }
    }
}
