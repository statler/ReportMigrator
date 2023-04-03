
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class SiteDiaryNotificationFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.SiteDiary_Notification;

        public SiteDiaryNotificationFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetSet<SiteDiarySetTemplateDto>("Site_Diaries", "SiteDiaries", GetSiteDiaryTemplateFields);
        }


        private static List<TemplateField> GetSiteDiaryTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>
            {
                new TemplateField("Site_Diary_No", "SiteDiaryNo"),
                new TemplateField("Diary_By", "DiaryByName"),
                new TemplateField("Diary_date", "DiaryDateString"),
                new TemplateField("Reviewed_By", "ReviewedByName"),
                new TemplateField("Date_Reviewed", "DateReviewedString"),
                new TemplateField("Diary_No_With_Link", "SiteDiaryLink"),
                new TemplateField("Diary_Link_AsURL", "SiteDiaryLinkSiteURL")
            };

            return lstFields;
        }
    }
}
