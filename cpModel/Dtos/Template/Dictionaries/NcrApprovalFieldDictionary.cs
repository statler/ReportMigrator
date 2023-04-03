
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class NcrApprovalFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Approval_NCR;

        public NcrApprovalFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetNcrTemplateFields(true);
        }


        public static List<TemplateField> GetNcrTemplateFields(bool InclLots)
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            lstFields.Add(new TemplateField("Project_Name", "ProjectName"));
            lstFields.Add(new TemplateField("Project_Number", "ProjectNumber"));
            lstFields.Add(new TemplateField("NCR_No", "NcrNo"));
            lstFields.Add(new TemplateField("NCR_Description", "Description"));
            lstFields.Add(new TemplateField("NCR_Date", "DateRaisedString"));
            lstFields.Add(new TemplateField("Status", "Status"));
            lstFields.Add(new TemplateField("NCR_Corrective", "CorrectiveAction"));
            lstFields.Add(new TemplateField("NCR_Preventative", "PreventativeAction"));
            lstFields.Add(new TemplateField("NCR_No_With_Link", "NcrLink"));
            lstFields.Add(new TemplateField("NCR_Link_AsURL", "NcrLinkSiteURL"));

            if (InclLots)
            {
                var ai = new TemplateField("Lots", "Lots");
                ai.AddSubField(new TemplateField("Lot_Number", "LotNumber"));
                ai.AddSubField(new TemplateField("Lot_Description", "Description"));
                lstFields.Add(ai);
            }

            return lstFields;
        }
    }
}
