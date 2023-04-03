
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class ChecklistApprovalFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Approval_Check;

        public ChecklistApprovalFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetChecklistTemplateFields();
        }

        public static List<TemplateField> GetChecklistTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            lstFields.Add(new TemplateField("Project_Number", "ProjectNumber"));
            lstFields.Add(new TemplateField("Project_Name", "ProjectName"));
            lstFields.Add(new TemplateField("Reference_Text", "ReferenceText_Plain"));
            lstFields.Add(new TemplateField("Reference_Text_Rich", "ReferenceText"));
            lstFields.Add(new TemplateField("Check_Text", "Description"));
            lstFields.Add(new TemplateField("Spec_Clause", "Clause"));
            lstFields.Add(new TemplateField("Responsibility", "Responsibility"));
            lstFields.Add(new TemplateField("Check_Type", "CheckType", "ItemTypeString"));
            lstFields.Add(new TemplateField("Checklist_Description", "Description"));
            lstFields.Add(new TemplateField("Lot_Number", "LotNumber"));
            lstFields.Add(new TemplateField("Lot_Description", "LotDescription"));
            lstFields.Add(new TemplateField("ITP_Doc_Number", "ItpDocNo"));
            lstFields.Add(new TemplateField("ITP_Name", "ItpName"));
            lstFields.Add(new TemplateField("Checklist_Link_As_Description", "ChecklistLink"));
            lstFields.Add(new TemplateField("Checklist_Link_As_Site_URL", "ChecklistLinkSiteURL"));
            return lstFields;

        }

    }
}
