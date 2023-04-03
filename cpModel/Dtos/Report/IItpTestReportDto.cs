namespace cpModel.Dtos.Report
{
    public interface IItpTestReportDto
    {
        int? ParentId { get; }
        int RecordId { get; }
        string Comment { get; set; }
        string Compliance { get; set; }
        decimal? FreqLotNorm { get; set; }
        decimal? FreqLotRed { get; set; }
        decimal? FreqNorm { get; set; }
        decimal? FreqRed { get; set; }
        bool? IsDefault { get; set; }
        bool? IsOptional { get; set; }
        int? OrSet { get; set; }
        int? QuantityBasis { get; set; }
        int? TestMethodId { get; set; }
        string Unit { get; set; }
        string TestString { get; }
        string FreqString { get; }
    }
}
