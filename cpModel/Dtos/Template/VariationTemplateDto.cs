namespace cpModel.Dtos.Template
{
    public class VariationTemplateDto : VariationDto
    {
        public decimal? RateSubmitted
        {
            get
            {
                if ((QtySubmitted ?? 0) == 0 || SellTotalSubmitted == null) return null;
                else return SellTotalSubmitted / QtySubmitted;
            }
        }
        public decimal? RateApproved
        {
            get
            {
                if ((QtyApproved ?? 0) == 0 || SellTotalApproved == null) return null;
                else return SellTotalApproved / QtyApproved;
            }
        }
        public string VariationNoDesc => $"{VariationNo}: {Description}";
        public string DateIdentifiedAsString => DateIdentified?.ToShortDateString() ?? "";
        public string DateNotifiedAsString => DateNotified?.ToShortDateString() ?? "";
        public string DateSubmittedAsString => DateSubmitted?.ToShortDateString() ?? "";
        public string DateApprovedAsString => DateApproved?.ToShortDateString() ?? "";
        public string QtySubmittedAsString => QtySubmitted?.ToString("#,###,##0.#######") ?? "";
        public string QtyApprovedAsString => QtyApproved?.ToString("#,###,##0.#######") ?? "";
        public string RateSubmittedAsString => RateSubmitted?.ToString("c2") ?? "";
        public string RateApprovedAsString => RateApproved?.ToString("c2") ?? "";
        public string TotalSubmittedAsString => SellTotalSubmitted?.ToString("c2") ?? "";
        public string TotalApprovedAsString => SellTotalApproved?.ToString("c2") ?? "";
    }
}
