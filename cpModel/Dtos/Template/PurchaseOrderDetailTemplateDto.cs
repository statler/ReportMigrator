using HtmlAgilityPack;

namespace cpModel.Dtos.Template
{
    public partial class PurchaseOrderDetailTemplateDto : PurchaseOrderDetailDto
    {
        public string ItemNumberString => (ItemNumber ?? 0).ToString("#,###,##0.##");
        public string QtyString => Qty.HasValue ? Qty.Value.ToString("#,###,##0.######") : "";
        public string RateString => Rate.HasValue ? Rate.Value.ToString("C2") : "";
        public string TotalString => Total.HasValue ? Total.Value.ToString("C2") : "";
        public string DisplayQtyString => DisplayQty.HasValue ? DisplayQty.Value.ToString("#,###,##0.######") : "";
        public string DisplayTotalString => DisplayTotal.HasValue ? DisplayTotal.Value.ToString("C2") : "";
        public string DescriptionHtmlNoDoc
        {
            get
            {
                if (string.IsNullOrEmpty(ItemDescription)) return null;
                HtmlDocument hd = new HtmlDocument();
                hd.LoadHtml(ItemDescription);
                return hd.DocumentNode.InnerHtml;
            }
        }
    }
}
