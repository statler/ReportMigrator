
using cpModel.Helpers;
namespace cpModel.Dtos
{
    public partial class ApprovalLotItpDetailDto
    {
        public int ApprovalLotItpDetailId { get; set; }
        public int? ApprovalId { get; set; }
        public int? LotItpDetailId { get; set; }
        public int? ApprovalNo { get; set; }
        public string ApprovalSubjectHtml { get; set; }
        public string ApprovalSubjectPlainText => ApprovalSubjectHtml.GetPlainTextFromHTML();
        public string LotNo { get; set; }
        public string ItpRef { get; set; }
        public int? LotItpId { get; set; }
        public string Lot_ItpRef => $"{LotNo ?? ""}: {ItpRef ?? ""}";

    }
}
