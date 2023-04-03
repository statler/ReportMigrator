
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class PurchaseOrderNotificationFieldDictionary : PurchaseOrderApprovalFieldDictionary, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Approval_PO;

        public PurchaseOrderNotificationFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetSet<PurchaseOrderSetTemplateDto>("Purchase_Orders", "PurchaseOrders", () => GetPOTemplateNotificationFields());
        }

        List<TemplateField> GetPOTemplateNotificationFields()
        {
            List<TemplateField> lstFields = GetPOTemplateFields(false, false);
            lstFields.Add(new TemplateField("PO_Ref_With_Link", "PurchaseOrderLink"));
            lstFields.Add(new TemplateField("PO_Link_As_Site_URL", "PurchaseOrderLinkSiteURL"));
            return lstFields;
        }
    }
}
