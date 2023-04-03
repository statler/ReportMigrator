
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class AtpNotificationFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Atp_Notification;

        public AtpNotificationFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetSet<AtpSetTemplateDto>("Atps", "Atps", GetAtpTemplateFields);
        }

        private static List<TemplateField> GetAtpTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>
            {
                new TemplateField("Atp_No", "AtpNo"),
                new TemplateField("Description", "Description"),
                new TemplateField("Atp_By", "RequestedByName"),
                new TemplateField("Atp_To", "SentToName"),
                new TemplateField("Date_Submitted", "DateSubmittedString"),
                new TemplateField("Date_Response_Reqd", "DateResponseReqdString"),
                new TemplateField("Atp_No_With_Link", "AtpLink"),
                new TemplateField("Atp_Link_AsURL", "AtpLinkSiteURL")
            };

            return lstFields;
        }
    }
}
