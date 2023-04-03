namespace cpModel.Dtos.Report
{
    public partial class LotItpTestReportDto : LotItpTestDto, IItpTestReportDto
    {
        public int RecordId => LotItpTestId;
        public int? ParentId => LotItpDetailId;
    }
}
