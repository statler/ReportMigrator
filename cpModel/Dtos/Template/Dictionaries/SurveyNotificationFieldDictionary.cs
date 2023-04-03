using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.Template
{
    internal class SurveyNotificationFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Survey_Request_Notification;

        public SurveyNotificationFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetSurveyRequestSetTemplateFields();
        }

        public static List<TemplateField> GetSurveyRequestSetTemplateFields()
        {
            var lstFields = GetSet<SurveyRequestSetTemplateDto>("Survey_Requests", "SurveyRequests", GetSurveyRequestTemplateFields);
            lstFields.Add(AddFsTemplates<FsSurveyRequestTemplateDto>("Filestore_SurveyReqNo", "SrNumber"));
            return lstFields;
        }

        public static List<TemplateField> GetSurveyRequestTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>
            {
                new TemplateField("Survey_Req_No", "SrNumber"),
                new TemplateField("Survey_Req_To", "RequestToName"),
                new TemplateField("Survey_Req_By", "RequestByName"),
                new TemplateField("Date_Raised", "DateRequestString"),
                new TemplateField("Date_Required", "DateRequiredString"),
                new TemplateField("Survey_Description", "Description"),
                new TemplateField("Survey_Type", "SurveyTypeDesc"),
                new TemplateField("Lot_Info_CSV", "LotInfoCSVString"),
                new TemplateField("Has_Files", "HasFiles"),
                new TemplateField("Survey_Req_No_With_Link", "SurveyReqLink"),
                new TemplateField("Survey_Req_Link_AsURL", "SurveyReqLinkSiteURL")
            };

            return lstFields;
        }
    }
    }
