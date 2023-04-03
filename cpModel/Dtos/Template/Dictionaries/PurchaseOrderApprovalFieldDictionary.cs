
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class PurchaseOrderApprovalFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.PurchaseOrder_Notification;

        public PurchaseOrderApprovalFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetPOTemplateFields(true, true);
        }

        public static List<TemplateField> GetPOTemplateFields(bool inclProjectData, bool inclItems)
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            if (inclProjectData)
            {
                lstFields.Add(new TemplateField("Project_Number", "ProjectNumber"));
                lstFields.Add(new TemplateField("Project_Name", "ProjectName"));
            }
            lstFields.Add(new TemplateField("PO_No", "PoNumber"));
            lstFields.Add(new TemplateField("PO_Date", "PoDateString"));
            lstFields.Add(new TemplateField("PO_Supplier", "SupplierName"));
            lstFields.Add(new TemplateField("PO_RaisedBy", "RaisedByName"));
            lstFields.Add(new TemplateField("PO_Total", "PoValueString"));
            lstFields.Add(new TemplateField("PO_Total_Display", "PoValueDisplayString"));
            lstFields.Add(new TemplateField("PO_Budget", "PoBudgetString"));
            lstFields.Add(new TemplateField("PO_Budget_Variance", "PoVarianceString"));
            lstFields.Add(new TemplateField("PO_Budget_Variance_Percent", "PoVariancePercString"));
            lstFields.Add(new TemplateField("PO_Comments", "Comments"));
            if (inclItems)
            {
                var ai = new TemplateField("Purchase_Order_Details", "PurchaseOrderDetailsOrdered");
                ai.AddSubField(new TemplateField("Item_Number", "ItemNumberString"));
                ai.AddSubField(new TemplateField("Item_Description", "DescriptionHtmlNoDoc"));
                ai.AddSubField(new TemplateField("Item_Qty", "QtyString"));
                ai.AddSubField(new TemplateField("Item_Qty_Display", "DisplayQtyString"));
                ai.AddSubField(new TemplateField("Item_Rate", "RateString"));
                ai.AddSubField(new TemplateField("Item_Total", "TotalString"));
                ai.AddSubField(new TemplateField("Item_Total_Display", "DisplayTotalString"));
                lstFields.Add(ai);
            }

            return lstFields;
        }
    }
}
