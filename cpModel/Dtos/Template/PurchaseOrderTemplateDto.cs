using cpModel.Enums;
using cpModel.Helpers;
using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public partial class PurchaseOrderTemplateDto : PurchaseOrderDto
    {
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public decimal PoVariance => (PoValue - PoBudget ?? 0);

        public decimal PoVariancePerc => (PoBudget ?? 0) == 0 ? 0 : (PoValue - PoBudget.Value) / PoBudget.Value;

        public ICollection<PurchaseOrderDetailTemplateDto> PurchaseOrderDetailsOrdered { get; set; }

        public string PoValueString => PoValue.ToString("C2");
        public string PoValueDisplayString => PoValueDisplay.ToString("C2");
        public string PoVarianceString => PoVariance.ToString("C2");
        public string PoBudgetString => (PoBudget ?? 0).ToString("C2");
        public string PoVariancePercString => PoVariancePerc.ToString("P1");
        public string PoDateString => PoDate == null ? "" : PoDate.Value.ToString("d");

        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Purchase_Order, PurchaseOrderId);
        public string MobileSiteURL => APIConstants.MobileSiteURL;

        public string PurchaseOrderLink => $@"<a href='{URL}'>PO:{PoNumber}</a>";
        public string PurchaseOrderLinkSiteURL => $@"<a href='{URL}'>{MobileSiteURL}</a>";
    }

}
