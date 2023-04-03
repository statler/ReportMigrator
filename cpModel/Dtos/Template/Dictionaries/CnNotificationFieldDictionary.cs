
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class CnNotificationFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Contract_Notice_Notification;

        public CnNotificationFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetSet<CnSetTemplateDto>("Contract_Notices", "ContractNotices", GetCnTemplateFields);
        }

        private static List<TemplateField> GetCnTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>
            {
                new TemplateField("Notice_Reference", "ConRef"),
                new TemplateField("Subject", "ConSubjectPlainText"),
                new TemplateField("Notice_Date", "ConDateAsString"),
                new TemplateField("Notice_From", "RequestByName"),
                new TemplateField("Notice_To", "NoticeToCsv"),
                new TemplateField("Notice_On_Behalf", "RequestOnBehalfName"),
                new TemplateField("Date_Sent", "DateSentAsString"),
                new TemplateField("Date_Response_reqd", "DateResponseRequiredAsString"),
                new TemplateField("Number_Responses", "NumberOfResponses"),
                new TemplateField("Number_Actioned_Responses", "NumberOfActionedResponses"),
                new TemplateField("Notice_Ref_With_Link", "CnLink"),
                new TemplateField("Notice_Link_AsURL", "CnLinkSiteURL")
            };

            return lstFields;
        }
    }
}
