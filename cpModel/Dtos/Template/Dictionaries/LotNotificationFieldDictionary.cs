
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class LotNotificationFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Lot_Notification;

        public LotNotificationFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetSet<LotSetTemplateDto>("Lots", "Lots", GetLotTemplateFields);
        }

        private static List<TemplateField> GetLotTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>
            {
                new TemplateField("Lot_No", "LotNumber"),
                new TemplateField("Description", "Description"),
                new TemplateField("Raised_By", "RaisedByName"),
                new TemplateField("Date_Open", "DateOpenString"),
                new TemplateField("Date_Guar", "DateGuarString"),
                new TemplateField("Date_Conf", "DateConfString"),
                new TemplateField("Days_Open", "DaysOpen"),
                new TemplateField("Status", "LotStatus"),
                new TemplateField("Lot_No_With_Link", "LotLink"),
                new TemplateField("Lot_Link_AsURL", "LotLinkSiteURL")
            };

            return lstFields;
        }
    }
}
