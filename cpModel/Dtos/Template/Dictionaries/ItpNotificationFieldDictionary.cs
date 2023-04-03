
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class ItpNotificationFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Itp_Notification;

        public ItpNotificationFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetSet<ItpSetTemplateDto>("Itps", "Itps", GetItpTemplateFields);
        }

        private static List<TemplateField> GetItpTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>
            {
                new TemplateField("Itp_Doc_No", "ItpDocnumber"),
                new TemplateField("Description", "Description"),
                new TemplateField("Spec_Reference", "SpecRef"),
                new TemplateField("Revision_Date", "RevisionDateAsString"),
                new TemplateField("Date_Approved", "ApprovalDateAsString"),
                new TemplateField("Itp_No_With_Link", "ItpLink"),
                new TemplateField("Itp_Link_AsURL", "ItpLinkSiteURL")
            };

            return lstFields;
        }
    }
}
