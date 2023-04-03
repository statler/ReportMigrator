
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class PurchaseOrderBaseFieldDictionary : PurchaseOrderApprovalFieldDictionary, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Purchase_Order;

        public PurchaseOrderBaseFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            List<TemplateField> lstFields = GetPOTemplateFields(true, true);
            lstFields.Add(new TemplateField("PO_Ref_With_Link", "PurchaseOrderLink"));
            lstFields.Add(new TemplateField("PO_Link_As_Site_URL", "PurchaseOrderLinkSiteURL"));
            return lstFields;
        }

    }
}
