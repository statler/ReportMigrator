
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class NcrNotificationFieldDictionary : NcrApprovalFieldDictionary, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Ncr_Notification;

        public NcrNotificationFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetSet<NcrSetTemplateDto>("Ncrs", "Ncrs", () => GetNcrTemplateFields(false));
        }

    }
}
