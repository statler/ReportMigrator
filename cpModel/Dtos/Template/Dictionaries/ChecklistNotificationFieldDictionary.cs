
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class ChecklistNotificationFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Checklist_Notification;

        public ChecklistNotificationFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetSet<LotItpSetTemplateDto>("Checklists", "LotItps", GetChecklistTemplateFields);
        }

        public static List<TemplateField> GetChecklistTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            lstFields.Add(new TemplateField("Lot_Number", "LotNumber"));
            lstFields.Add(new TemplateField("Itp_Name", "ItpDescription"));
            lstFields.Add(new TemplateField("Description", "Description"));
            lstFields.Add(new TemplateField("Raised_By", "RaisedByName"));
            lstFields.Add(new TemplateField("Checklist_Date", "ChecklistDateString"));
            lstFields.Add(new TemplateField("Lot_Status", "Status"));
            lstFields.Add(new TemplateField("Checklist_Link_As_Description", "ChecklistLink"));
            lstFields.Add(new TemplateField("Checklist_Link_As_Site_URL", "ChecklistLinkSiteURL"));
            return lstFields;
        }

    }
}
